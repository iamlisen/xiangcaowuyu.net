using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Public.ProductHelper;
using xiangcaowuyu.net.Public.MenuHelper;
using xiangcaowuyu.net.Public;
using Newtonsoft.Json;

namespace xiangcaowuyu.net.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductHelper productHelper;

        public ProductController(IProductHelper productHelper,IMenuHelper menuHelper):base(menuHelper) 
        {
            this.productHelper = productHelper;
        }
        public IActionResult Index(int pageIndex = 1)
        {           
            return View();
        }

        public ActionResult GetData(int limit=1,int offset=4)
        {
            var rows = productHelper.GetProductPager(limit, offset);
            int total = rows.Count();
            //转成Json格式
            return Json(new { total = total, rows = rows });
        }
    }
}