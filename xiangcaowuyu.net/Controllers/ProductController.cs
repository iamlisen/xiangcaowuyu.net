using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Public.ProductHelper;
using xiangcaowuyu.net.Public.MenuHelper;
using xiangcaowuyu.net.Public;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using xiangcaowuyu.net.Models.Entity;

namespace xiangcaowuyu.net.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductHelper productHelper;

        public ProductController(IProductHelper productHelper, IMenuHelper menuHelper) : base(menuHelper)
        {
            this.productHelper = productHelper;
        }
        public IActionResult Index(int pageIndex = 1)
        {
            return View();
        }

        public ActionResult GetData(int limit = 1, int offset = 4)
        {
            var rows = productHelper.GetProductPager(limit, offset);
            int total = productHelper.GetProducts().Count;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.MaxDepth = 50;
            //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; //设置不处理循环引用
            //转成Json格式
            return Json(new { total = total, rows = rows }, settings);
            //return Json(new { total = total, rows = rows });
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        [Authorize(Roles = "admin")]
        public ActionResult AddProduct(Product product)
        {
            return View(product);
        }

        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public ActionResult SaveProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return AddProduct(product);
            }
            if (productHelper.SaveProduct(product) == "1")
            {
                return View(product);
            }
            else
            {
                return AddProduct(product);
            }
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewProduct(string id)
        {
            Product product = productHelper.GetProduct(id);
            return View(product);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        public ActionResult EditProduct(string id)
        {
            Product product = productHelper.GetProduct(id);
            return View(product);
        }

        public ActionResult List(int limit = 8, int offset = 0)
        {
            var rows = productHelper.GetProductPager(limit, offset);
            ViewBag.ProductList = rows;
            return View();
        }

        public ActionResult GetDataList(int limit = 8, int offset =0)
        {
            var rows = productHelper.GetProductPager(limit, offset);
            return Json(new { rows=rows},new JsonSerializerSettings());
        }
    }
}