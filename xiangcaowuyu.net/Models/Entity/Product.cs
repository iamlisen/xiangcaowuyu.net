﻿using System;
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
        [Display(Name = "产品编号")]
        [Required(ErrorMessage ="请输入产品编号")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Display(Name = "产品名称")]
        [Required(ErrorMessage ="请输入产品名称")]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [Display(Name = "产品描述")]
        [Required(ErrorMessage ="请输入产品描述")]
        public string ProductContent { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        [Display(Name = "产品价格")]
        [Required(ErrorMessage ="请输入产品价格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        [Display(Name = "产品数量")]
        public decimal Count { get; set; }

        /// <summary>
        /// 剩余数量
        /// </summary>
        [Display(Name = "剩余数量")]
        public decimal Surplus { get; set; }

        /// <summary>
        /// 是否热销
        /// </summary>
        [Display(Name = "是否热销")]
        public string IsHot { get; set; }

        /// <summary>
        /// 是否包邮
        /// </summary>
        [Display(Name = "是否包邮")]
        public string IsFreeExpress { get; set; }

        /// <summary>
        /// 邮费
        /// </summary>
        [Display(Name = "邮费")]
        [DataType(DataType.Text)]
        public decimal ExpressFee { get; set; }

        /// <summary>
        /// 推荐等级
        /// </summary>
        [Display(Name = "推荐等级")]
        [Range(0, 5,ErrorMessage ="范围值应该介于0~5之间")]
        [Required(ErrorMessage ="请输入推荐等级")]
        public int HotLevel { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        [Display(Name = "产品图片")]
        [Required(ErrorMessage ="请输入产品图片")]
        public string Picture { get; set; }

        /// <summary>
        /// 鼠标滑过图片
        /// </summary>
        [Display(Name = "鼠标滑过图片")]
        public string MouseMovePicture { get; set; }

        /// <summary>
        /// 淘宝链接
        /// </summary>
        [Display(Name = "淘宝链接")]
        [Required(ErrorMessage ="淘宝链接不能为空")]
        public string TaoBaoUrl { get; set; }

        [Display(Name ="微店链接")]
        [Required(ErrorMessage ="微店链接不能为空")]
        public string WeiDianUrl { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime? CreateTime { get; set; }
    }
}
