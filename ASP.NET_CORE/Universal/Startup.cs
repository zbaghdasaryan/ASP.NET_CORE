using System.Collections.Specialized;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Universal
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routebuilder = new RouteBuilder(app);

            routebuilder.MapRoute("{controler}",
                async (context) =>
                {
                    await context.Response.WriteAsync("{controler} template use");
                });

            routebuilder.MapRoute("{controler}/{action}",
               async (context) =>
               {
                   await context.Response.WriteAsync("{controler}/{action} template use");
               });

            routebuilder.MapRoute("{controler}/{action}/{id}",
              async (context) =>
              {
                  await context.Response.WriteAsync("{controler}/{action}/{id} template use");
              });

            routebuilder.MapRoute("{controler}/{action}/{id?}",
             async (context) =>
             {
                 await context.Response.WriteAsync("{controler}/{action}/{id} template use");
             });

            routebuilder.MapRoute("{controler}/{action}/{id}/{*catchall}",
             async (context) =>
             {
                 await context.Response.WriteAsync("{controler}/{action}/{id} template use");
             });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default Page!");
            });
        }
    }
}
