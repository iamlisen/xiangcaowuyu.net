using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models.Entity;
using xiangcaowuyu.net.Public.Enum;

namespace xiangcaowuyu.net.Public.ProductHelper
{
    public interface IProductHelper
    {
        /// <summary>
        /// 获取所有产品列表
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();

        /// <summary>
        /// 根据ID获取产品
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>获取的唯一产品</returns>
        Product GetProductById(string id);

        /// <summary>
        /// 根据产品编号获取产品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Product GetProductByCode(string code);

        /// <summary>
        /// 返回排序后的列表
        /// </summary>
        /// <param name="sort">排序字段，多个字段,隔开</param>
        /// <param name="sortType">升序Or降序</param>
        /// <returns></returns>
        List<Product> GetProductsSort(string sort, SortType sortType);

        /// <summary>
        /// 获取首页产品
        /// </summary>
        /// <returns></returns>
        List<Product> GetProductIndex();

        /// <summary>
        /// 获取首页随机图片
        /// </summary>
        /// <returns></returns>
        List<Product> GetProductRandom();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">第几页面</param>
        /// <returns></returns>
        List<Product> GetProductPager(int limit, int offset);

        string SaveProduct(Product product);

        /// <summary>
        /// 根据ID获取产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProduct(string id);
    }
}
