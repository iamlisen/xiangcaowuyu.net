using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models;
using xiangcaowuyu.net.Models.Entity;

namespace xiangcaowuyu.net.Public
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
