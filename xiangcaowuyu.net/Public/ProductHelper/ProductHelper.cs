using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models.Entity;
using xiangcaowuyu.net.Public.Enum;
namespace xiangcaowuyu.net.Public.ProductHelper
{
    public class ProductHelper : IProductHelper
    {
        private readonly SqlDbContext sqlDbContext;
        public ProductHelper(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }

        public Product GetProduct(string id)
        {
            return sqlDbContext.Products.Where(e => e.ID == id).FirstOrDefault<Product>();
        }

        public Product GetProductByCode(string code)
        {
            Product product = sqlDbContext.Products.Where<Product>(e => e.ProductCode == code).FirstOrDefault();
            return product;
        }

        public Product GetProductById(string id)
        {
            Product product = sqlDbContext.Products.Where<Product>(e => e.ID == id).FirstOrDefault();
            return product;
        }

        public List<Product> GetProductIndex()
        {
            return sqlDbContext.Products.OrderByDescending(e => e.CreateTime).Take(8).ToList();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public List<Product> GetProductPager(int limit, int offset)
        {
            List<Product> list = sqlDbContext.Products.OrderByDescending(e => e.CreateTime).Skip(offset).Take(limit).ToList();
            return list;

        }

        /// <summary>
        /// 获取首页随机图片
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductRandom()
        {
            List<Product> list = sqlDbContext.Products.FromSql("SELECT TOP 15 * FROM Products order by NEWID()").ToList<Product>();
            return list;
        }

        public List<Product> GetProducts()
        {
            return sqlDbContext.Products.ToList<Product>();
        }

        public List<Product> GetProductsSort(string sort, SortType sortType)
        {
            throw new NotImplementedException();
        }

        public string SaveProduct(Product product)
        {
            if (product.ID == "")
            {
                product.ID = Guid.NewGuid().ToString();
                sqlDbContext.Products.Add(product);
            }
            else
            {
                sqlDbContext.Products.Update(product);
            }
            sqlDbContext.SaveChanges();
            return "1";
        }
    }
}
