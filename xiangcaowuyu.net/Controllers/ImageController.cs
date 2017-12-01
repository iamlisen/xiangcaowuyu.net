using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using xiangcaowuyu.net.Public;

namespace xiangcaowuyu.net.Controllers
{
    public class ImageController : Controller
    {
        [Authorize(Roles = "admin")]
        public ContentResult UploadImage()
        {
            var files = HttpContext.Request.Form.Files;
            string callback = HttpContext.Request.Query["CKEditorFuncNum"].ToString();
            var file = files.FirstOrDefault();
            var fileName = file.FileName;

            string fileContentType = file.ContentType.ToString();
            if (!(fileContentType == "image/bmp" || fileContentType == "image/gif" ||
                   fileContentType == "image/png" || fileContentType == "image/x-png" || fileContentType == "image/jpeg"
                   || fileContentType == "image/pjpeg"))
            {
                return this.Content("<script>alert('小主，只能上传图片。^_^')</script>", "text/html");
            }
            string filePath = Directory.GetCurrentDirectory() + @"\wwwroot\UploadImage";
            fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
            using (FileStream fs = new FileStream(filePath + "\\" + fileName, FileMode.Create))
            {
                file.CopyTo(fs);
            }
            string imageurl = "/UploadImage/" + fileName;
            return this.Content("<script>window.parent.CKEDITOR.tools.callFunction(" + callback
                               + ",'" + imageurl + "','')</script>", "text/html");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public JsonResult UploadOnlyImage(IFormFile fileinput)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                var file = files.FirstOrDefault();
                var fileName = file.FileName;
                string fileContentType = file.ContentType.ToString();
                if (!(fileContentType == "image/bmp" || fileContentType == "image/gif" ||
                       fileContentType == "image/png" || fileContentType == "image/x-png" || fileContentType == "image/jpeg"
                       || fileContentType == "image/pjpeg"))
                {
                    return Json(new { msg = "小主，只能上传图片", status = "false" });
                }
                string filePath = Directory.GetCurrentDirectory() + @"\wwwroot\UploadImage";
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                using (FileStream fs = new FileStream(filePath + "\\" + fileName, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                string imageurl = "/UploadImage/" + fileName;
                WriteLogs.WriteLog("log.log", "exception", "111111111111111");
                return Json(new { msg = fileName, status = "false" }, new Newtonsoft.Json.JsonSerializerSettings());
               
            }
            catch (Exception ex)
            {
                WriteLogs.WriteLog("log.log", "exception", ex.Message);
                return null;
            }
        }
    }
}