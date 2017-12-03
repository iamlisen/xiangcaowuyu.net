using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models;

namespace xiangcaowuyu.net.Public.BannerHelper
{
    public class BannerHelper : IBannerHelper
    {
        private readonly SqlDbContext sqlDbContext;
        public BannerHelper(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }
        public List<Banner> GetBanners()
        {
            return sqlDbContext.Banner.ToList<Banner>();

        }
    }
}
