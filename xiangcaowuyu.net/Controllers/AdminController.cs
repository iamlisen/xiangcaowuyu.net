using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.xiangcaowuyu.net;
using System.IO;
using Microsoft.AspNetCore.Http;
using xiangcaowuyu.net.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using xiangcaowuyu.net.Public;

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
        public async Task<string> CheckLogin()
        {
            string result = "";
            string userName = HttpContext.Request.Form["username"].ToString();
            string passWord = HttpContext.Request.Form["password"].ToString();
            string verifyCode = HttpContext.Request.Form["verifycode"].ToString();
            if (userName != ConfigManager.GetConfig("userName") || passWord !=ConfigManager.GetConfig("password"))
            {
                result = "用户名或密码不正确";
                return result;
            }
            if (HttpContext.Session.Get("verifyCode") == null || string.IsNullOrEmpty(HttpContext.Session.Get("verifyCode").ToString()))
            {
                result = "验证码已过期，请重新刷新验证码";
                return result;
            }
            if (HttpContext.Session.GetString("verifyCode").ToString().ToLower() != verifyCode.ToLower())
            {
                result = "验证码输入错误，请重新输入";
                return result;
            }
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, userName));
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            UserInfo.UserName = userName;
            UserInfo.LoginTime = DateTime.Now;
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            HttpContext.Response.Cookies.Append("islogin","true");
            return result;
        }

        /// <summary>
        ///默认后台
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        public ActionResult Default()
        {
            return View();
        }
    }
}