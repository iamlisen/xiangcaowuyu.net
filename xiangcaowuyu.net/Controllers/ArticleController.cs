using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xiangcaowuyu.net.Models.Entity;
using xiangcaowuyu.net.Public.ArticleHelper;
using xiangcaowuyu.net.Public.MenuHelper;
using Microsoft.AspNetCore.Authorization;
using xiangcaowuyu.net.Public.Attribute;

namespace xiangcaowuyu.net.Controllers
{
    [StaticFileHandlerFilter(Key = "id")]
    public class ArticleController : BaseController
    {
        private readonly IArticleHelper articleHelper;

        public ArticleController(IArticleHelper articleHelper, IMenuHelper menuHelper) : base(menuHelper)
        {
            this.articleHelper = articleHelper;
        }

        // GET: Article
        public ActionResult Index()
        {
            List<Article> list = articleHelper.GetList();
            return View(list);
        }

        // GET: Article/Details/5
        [StaticFileHandlerFilter(Key = "id")]
        public ActionResult Details(string id)
        {
            Article article = articleHelper.GetArticle(id);
            return View(article);
        }

        // GET: Article/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Article article)
        {
            try
            {
                articleHelper.InsertArticle(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string id)
        {
            Article article = articleHelper.GetArticle(id);
            return View(article);
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string id, Article article)
        {
            try
            {
                // TODO: Add update logic here
                articleHelper.EditArticle(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            if (articleHelper.DeleteArticle(id))
            {
                ViewBag.IsDeleted = "删除成功";
            }
            else
            {
                ViewBag.IsDeleted = "删除失败";
            }
            return View();
        }

        // POST: Article/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}