using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Models;
using xiangcaowuyu.net.Public.MenuHelper;
using xiangcaowuyu.net.Public.BannerHelper;

namespace xiangcaowuyu.net.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBannerHelper bannerHelper;
        public HomeController(IMenuHelper menuHelper,IBannerHelper bannerHelper) : base(menuHelper)
        {
            this.bannerHelper = bannerHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            /*获取banner*/
            ViewBag.Banners = bannerHelper.GetBanners();
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
