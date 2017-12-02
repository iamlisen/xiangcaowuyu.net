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
        [MaxLength(200, ErrorMessage = "文章标题不能超过50个字符")]
        public string Title { get; set; }
        [Required(ErrorMessage = "请输入文章内容")]
        public string Context { get; set; }
        public DateTime? PostTime { get; set; }
        public int IsHot { get; set; }
        public string Type { get; set; }
    }
}
