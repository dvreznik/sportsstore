using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsStore.Models;


namespace SportsStore
{
    public class Startup
    {
        IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(_configuration["Data:SportStoreProducts:ConnectionString"]));   
            services.AddMvc();
            services.AddTransient<IProductRepository, EFProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:null,
                    template:"{category}/Page{page:int}",
                    defaults: new {controller = "Product",action = "List"});
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { Controller = "Product", action = "List", page = 1});
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { Controller = "Product", action = "List", page = 1 });
                routes.MapRoute(
                    name: null,
                    template:"",
                    defaults: new { Controller = "Product", action = "List", page = 1 });
                routes.MapRoute(
                    name: null,
                    template: "{controller=Product}/{action=List}/{id?}");
            });
            // start db action
            SeedData.EnsurePopulated(app);
        }
    }
}
