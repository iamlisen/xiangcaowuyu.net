using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace xiangcaowuyu.net.Controllers
{
    public class ImageController : Controller
    {
        [Authorize(Roles = "admin")]
        public void UploadImage()
        {
            var file = HttpContext.Request.Form.Files;
        }
    }
}