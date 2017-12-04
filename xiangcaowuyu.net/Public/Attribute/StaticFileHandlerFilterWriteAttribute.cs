using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiangcaowuyu.net.Public.Attribute
{
    /// <summary>
    /// 实现伪静态
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class StaticFileHandlerWriteFilterAttribute : ActionFilterAttribute
    {
        public string Key
        {
            get; set;
        }
        /// <summary>
        /// 动作执行后
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //获取结果
            IActionResult actionResult = context.Result;
            ViewResult viewResult = actionResult as ViewResult;
            //下面的代码就是执行这个ViewResult，并把结果的html内容放到一个StringBuiler对象中
            var services = context.HttpContext.RequestServices;
            var executor = services.GetRequiredService<ViewResultExecutor>();
            var option = services.GetRequiredService<IOptions<MvcViewOptions>>();
            var result = executor.FindView(context, viewResult);
            result.EnsureSuccessful(originalLocations: null);
            var view = result.View;
            StringBuilder builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                var viewContext = new ViewContext(
                    context,
                    view,
                    viewResult.ViewData,
                    viewResult.TempData,
                    writer,
                    option.Value.HtmlHelperOptions);
                view.RenderAsync(viewContext).GetAwaiter().GetResult();
                //这句一定要调用，否则内容就会是空的
                writer.Flush();
            }
            //按照规则生成静态文件名称
            string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
            string actionName = context.RouteData.Values["action"].ToString().ToLower();
            string id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString() : "";
            if (string.IsNullOrEmpty(id) && context.HttpContext.Request.Query.ContainsKey(Key))
            {
                id = context.HttpContext.Request.Query[Key];
            }
            string devicedir = Path.Combine(AppContext.BaseDirectory, "html");
            if (!Directory.Exists(devicedir))
            {
                Directory.CreateDirectory(devicedir);
            }
            //写入文件
            string filePath = Path.Combine(AppContext.BaseDirectory, "html", controllerName + "-" + actionName + (string.IsNullOrEmpty(id) ? "" : ("-" + id)) + ".html");
            using (FileStream fs = File.Open(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(builder.ToString());
                }
            }
            //输出当前的结果

        }

    }
}
