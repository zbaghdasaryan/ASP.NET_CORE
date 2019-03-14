using System.Collections.Specialized;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Routing
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

            routebuilder.MapRoute("/Home",
                async (context) =>
                {
                    await context.Response.WriteAsync("Home Page");
                });

            routebuilder.MapRoute("/Home/Courses",
               
               async (context) =>
               {
                   StringCollection courses = new StringCollection()
                   {
                       "C# courses",
                       "JS Courses",
                       "Java Cources",
                       "HTML CSS Cources"
                   };

                   await context.Response.WriteAsync("here of the list of avaliable courses");
                   foreach (var item in courses)
                   {
                       await context.Response.WriteAsync($"<br>{item}</br>");
                   }
               });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default Page!");
            });
        }
    }
}
