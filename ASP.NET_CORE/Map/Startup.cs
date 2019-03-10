using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Map
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/home", (z) =>
            {
                z.Map("/second", (appSecond) =>
                           {
                               appSecond.Run(async (context) =>
                               await context.Response.WriteAsync("home Map"));
                           });

            });


            app.Map("/index", (index) =>
            {
                index.Run(async (context) =>
                await context.Response.WriteAsync("<h1>index Map</h1>"));
            });

            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
