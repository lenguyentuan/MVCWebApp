using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class Startup
    {
        public static string ContentRootPath { set; get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<ProductInitService>();
            services.AddSingleton<PlanetService>();
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("MvcAppConnectionString");
                options.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute
                (
                    name: "dbManage",
                    pattern: "{controller}/{action}/{id?}",
                    areaName: "Database"
                );

                endpoints.MapAreaControllerRoute
                (
                    name: "product",
                    pattern: "{controller}/{action}/{id?}",
                    areaName: "ProductManage"
                );


                endpoints.MapControllerRoute(
                name: "ViewProduct",
                pattern: "ViewProduct/{id?}",
                defaults: new
                {
                    controller = "Product",
                    action = "Detail"
                }
            );


                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
