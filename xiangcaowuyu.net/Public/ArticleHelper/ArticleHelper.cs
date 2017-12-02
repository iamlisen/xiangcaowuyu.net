using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models.Entity;

namespace xiangcaowuyu.net.Public.ArticleHelper
{
    public class ArticleHelper : IArticleHelper
    {
        private readonly SqlDbContext sqlDbContext;

        public ArticleHelper(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteArticle(string id)
        {
            Article article = sqlDbContext.Articles.Where(e => e.ID == id).FirstOrDefault<Article>();
            sqlDbContext.Articles.Remove(article);
            if (sqlDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditArticle(string id)
        {
            Article article = sqlDbContext.Articles.Where(e => e.ID == id).FirstOrDefault<Article>();
            sqlDbContext.Articles.Update(article);
            if (sqlDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<Article> GetList(int index = -1)
        {
            if (index == -1)
            {
                return sqlDbContext.Articles.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool InsertArticle(Article article)
        {
            sqlDbContext.Add(article);
            if (sqlDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
