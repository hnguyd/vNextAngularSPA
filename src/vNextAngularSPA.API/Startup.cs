using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Cache.Memory;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using vNextAngularSPA.Data;
using vNextAngularSPA.Data.Infrastructure;
using vNextAngularSPA.Service;

namespace vNextAngularSPA.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();

            ////Add InMemoryCache
            //services.AddSingleton<IMemoryCache, MemoryCache>();

            //Dependency Injection
            services.AddTransient<IDatabaseFactory, DatabaseFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBookmarkedPlaceRepository, BookmarkedPlaceRepository>();
            services.AddTransient<IBookmarkedPlaceService, BookmarkedPlaceService>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
