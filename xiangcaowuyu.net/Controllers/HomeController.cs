using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Models;
using xiangcaowuyu.net.Public.MenuHelper;

namespace xiangcaowuyu.net.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMenuHelper menuHelper) : base(menuHelper)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            var aa = ViewData["Menus"];
            return View();
        }

        /// <summary>
        /// 护肤方法
        /// </summary>
        /// <returns></returns>
        public IActionResult SkinCareMethod()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 护肤品
        /// </summary>
        /// <returns></returns>
        public IActionResult SkinCareProduct()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        /// <summary>
        /// 新品发售
        /// </summary>
        /// <returns></returns>
        public IActionResult NewProduct()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        /// <summary>
        /// 护肤品评测
        /// </summary>
        /// <returns></returns>
        public IActionResult Evaluating()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
