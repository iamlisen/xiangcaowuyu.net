using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xiangcaowuyu.net.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace xiangcaowuyu.net.Public.MenuHelper
{
    public class MenuHelper : IMenuHelper
    {
        public SqlDbContext sqlDbContext;

        public MenuHelper(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }
        public List<Menu> GetList()
        {
            return sqlDbContext.Menu.ToList<Menu>();
        }
    }
}
