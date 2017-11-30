﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.xiangcaowuyu.net;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace xiangcaowuyu.net.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult GetVirifyCode()
        {
            string verifyCode = string.Empty;
            MemoryStream memoryStream = VerifyCode.CreateImage(out verifyCode);
            HttpContext.Session.SetString("verifyCode", verifyCode);
            return File(memoryStream.ToArray(), @"image/gif");
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string CheckLogin()
        {
            string result = "";
            string userName = HttpContext.Request.Form["username"].ToString();
            string passWord = HttpContext.Request.Form["password"].ToString();
            string verifyCode = HttpContext.Request.Form["verifycode"].ToString();
            if (userName != "hongrong" || passWord != "20160822")
            {
                result = "用户名或密码不正确";
                return result;
            }
            if(HttpContext.Session.Get("verifyCode")==null || string.IsNullOrEmpty(HttpContext.Session.Get("verifyCode").ToString()))
            {
                result = "验证码已过期，请重新刷新验证码";
                return result;
            }
            if(HttpContext.Session.GetString("verifyCode").ToString().ToLower() != verifyCode.ToLower())
            {
                result = "验证码输入错误，请重新输入";
                return result;
            }
            return result;
        }
    }
}