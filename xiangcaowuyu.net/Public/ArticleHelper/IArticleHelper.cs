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

        bool DeleteArticle(string id);

        List<Article> GetList(int index = -1);
    }
}
