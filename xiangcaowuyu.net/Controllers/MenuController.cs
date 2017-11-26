using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Public;
using xiangcaowuyu.net.Models;
using xiangcaowuyu.net.Public.MenuHelper;

namespace xiangcaowuyu.net.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuHelper menuHelper;
        public MenuController(IMenuHelper menuHelper)
        {
            this.menuHelper = menuHelper;
        }
        public List<Menu> GetMenus()
        {
            return menuHelper.GetList();
        }
    }
}