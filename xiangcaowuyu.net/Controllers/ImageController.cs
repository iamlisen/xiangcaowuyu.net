using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Web;

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
        public ContentResult UploadOnlyImage()
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
    }
}