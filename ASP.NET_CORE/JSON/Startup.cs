using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JSON
{
    public class Startup
    {
        public IConfiguration AppConfiguration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("JsonConfig.json");
            AppConfiguration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<p style='color: {AppConfiguration["color"]};'> {AppConfiguration["Content"]}</p>");
            });
        }
    }
}
