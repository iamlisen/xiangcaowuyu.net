using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using xiangcaowuyu.net.Public.MenuHelper;

namespace xiangcaowuyu.net.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMenuHelper menuHelper;
        public BaseController(IMenuHelper menuHelper)
        {
            this.menuHelper = menuHelper;
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           ViewData["menus"] = menuHelper.GetList();
            base.OnActionExecuting(context);
        }
    }
}