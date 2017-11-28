﻿using System;
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
            return sqlDbContext.Products.OrderByDescending(e => e.CreateTime).Take(9).ToList();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public List<Product> GetProductPager(int limit, int offset)
        {
            List<Product> list = sqlDbContext.Products.OrderByDescending(e => e.CreateTime).Take(limit).ToList();
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
    }
}
