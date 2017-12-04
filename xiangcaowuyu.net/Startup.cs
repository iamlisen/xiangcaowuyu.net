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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.StaticFiles;
using xiangcaowuyu.net.Public.ArticleHelper;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddDirectoryBrowser();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Admin/Index");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Error/Forbidden");
                });
            string sqlConnectionString = Configuration.GetSection("SqlServer").Value;
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(sqlConnectionString, b => b.UseRowNumberForPaging()));
            services.AddScoped<IMenuHelper, MenuHelper>()
                .AddScoped<IBannerHelper, BannerHelper>()
                .AddScoped<IProductHelper, ProductHelper>()
                .AddScoped<IArticleHelper, ArticleHelper>();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

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
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/UploadImage")),
                RequestPath = new PathString("/UploadImage"),
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true
            });
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
