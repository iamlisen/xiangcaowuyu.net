using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xiangcaowuyu.net.Models
{
    public class Menu
    {
        [Key]
        public string ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tips { get; set; }
        public string KeyWord { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
    }
}
