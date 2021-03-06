using BookStoreUsingDotnetCoreMvc.Data;
using BookStoreUsingDotnetCoreMvc.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUsingDotnetCoreMvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //To cretate the connection weith Db
            services.AddDbContext<BookStoreContext>(options => 
            options.UseSqlServer("Server=FMIC00100\\SQL2014FULL; Database=BookStore;Integrated Security=True"));
            
            //services.AddMvc();
            services.AddControllersWithViews();
            #if DEBUG
                  services.AddRazorPages().AddRazorRuntimeCompilation();
            #endif

            //Added dependency of BookRepository for the project
            services.AddScoped<BookRepository, BookRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();           

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //** it is the default route i.e cotroller and action method 
                endpoints.MapDefaultControllerRoute();  

                //**Custom route creation if we want to add 
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}"
                //    );

            });           
        }
    }
}
