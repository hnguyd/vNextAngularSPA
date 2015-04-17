using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.Cache.Memory;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using System;
using vNextAngularSPA.Data;
using vNextAngularSPA.Data.Infrastructure;
using vNextAngularSPA.Service;

namespace vNextAngularSPA.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
			// Setup configuration sources.
			Configuration = new Configuration()
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();
		}

		public IConfiguration Configuration { get; set; }

		// This method gets called by a runtime.
		// Use this method to add services to the container
		public void ConfigureServices(IServiceCollection services)
        {
			//Sql client not available on mono
			var useInMemoryStore = Type.GetType("Mono.Runtime") != null;

			if (useInMemoryStore)
			{
				services.AddEntityFramework(Configuration)
						.AddInMemoryStore()
						.AddDbContext<ApplicationDbContext>();
			}
			else
			{
				// Add EF services to the services container.
				services.AddEntityFramework(Configuration)
					.AddSqlServer()
					.AddDbContext<ApplicationDbContext>();
			}

			// Add Identity services to the services container.
			services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			//Add InMemoryCache
			services.AddSingleton<IMemoryCache, MemoryCache>();
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
