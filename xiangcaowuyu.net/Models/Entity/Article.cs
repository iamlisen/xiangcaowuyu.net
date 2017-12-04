using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xiangcaowuyu.net.Models.Entity
{
    public class Article
    {
        [Key]
        public string ID { get; set; }

        [Required(ErrorMessage = "请输入文章标题")]
        [Display(Name = "标题")]
        [MaxLength(200, ErrorMessage = "文章标题不能超过50个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage = "请输入文章内容")]
        [Display(Name = "内容")]
        public string Context { get; set; }

        [Display(Name = "发布日期")]
        public DateTime? PostTime { get; set; }

        [Display(Name = "是否推荐")]
        public int IsHot { get; set; }

        [Display(Name = "类型")]
        public string Type { get; set; }

        [Display(Name = "淘宝链接")]
        public string TaoBaoUrl { get; set; }

        [Display(Name = "微店链接")]
        public string WeiDianUrl { get; set; }

        [Display(Name ="图片链接")]
        public string Picture { get; set; }
    }
}
