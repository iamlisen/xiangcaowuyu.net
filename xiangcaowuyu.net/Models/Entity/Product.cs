using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xiangcaowuyu.net.Models.Entity
{
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public string ID { get; set; }
        
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string ProductContent { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        /// 剩余数量
        /// </summary>
        public decimal Surplus { get; set; }

        /// <summary>
        /// 是否热销
        /// </summary>
        public string IsHot { get; set; }

        /// <summary>
        /// 是否包邮
        /// </summary>
        public string IsFreeExpress { get; set; }

        /// <summary>
        /// 邮费
        /// </summary>
        public decimal ExpressFee { get; set; }

        /// <summary>
        /// 推荐等级
        /// </summary>
        public int HotLevel { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 鼠标滑过图片
        /// </summary>
        public string MouseMovePicture { get; set; }

        /// <summary>
        /// 淘宝链接
        /// </summary>
        public string TaoBaoUrl { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
