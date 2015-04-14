﻿using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using vNextAngularSPA.Data;
using Microsoft.AspNet.Hosting;

namespace vNextAngularSPA.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            
        }
        
        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {            
            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
            // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
            // services.AddWebApiConventions();			
		}

		// Configure is called after ConfigureServices is called.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                //Angular Catch All Route for SPA
                routes.MapRoute(
                    name: "Catch all route for SPA",
                    template: "{*catchall}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });

                // OOTB Routing 
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                
                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
        }
    }
}