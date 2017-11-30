using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xiangcaowuyu.net.Public;
using Microsoft.EntityFrameworkCore;
using xiangcaowuyu.net.Public.MenuHelper;
using xiangcaowuyu.net.Public.BannerHelper;
using xiangcaowuyu.net.Public.ProductHelper;

namespace xiangcaowuyu.net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
            string sqlConnectionString = Configuration.GetSection("SqlServer").Value;
            services.AddDbContext<SqlDbContext>(options=>options.UseSqlServer(sqlConnectionString,b => b.UseRowNumberForPaging()));
            services.AddScoped<IMenuHelper,MenuHelper>()
                .AddScoped<IBannerHelper,BannerHelper>()
                .AddScoped<IProductHelper,ProductHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
