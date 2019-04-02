using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MapWhen
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/home", home =>
            {
                home.Map("/index", Index);
                home.Map("/about", About);
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});

            app.MapWhen(context => {

                return context.Request.Query.ContainsKey("id") &&
                        context.Request.Query["id"] == "5";
            }, HandleId);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Good bye, World...");
            });
        }

        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }
    

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }

    }
}
