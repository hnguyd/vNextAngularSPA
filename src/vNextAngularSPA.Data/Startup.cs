using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Cache.Memory;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Identity;

namespace vNextAngularSPA.Data
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
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
        }
    }
}
