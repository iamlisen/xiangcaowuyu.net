using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models.Entity;

namespace xiangcaowuyu.net.Public.ArticleHelper
{
    public interface IArticleHelper
    {
        bool InsertArticle(Article article);

        bool EditArticle(string id);

        bool EditArticle(Article article);

        bool DeleteArticle(string id);

        List<Article> GetList(int index = -1);

        /// <summary>
        /// 根据ID获取唯一的文章
        /// </summary>
        /// <returns>The article.</returns>
        /// <param name="id">Identifier.</param>
        Article GetArticle(string id);
    }
}
