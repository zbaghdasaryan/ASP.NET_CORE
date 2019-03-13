using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetSection2
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(env.ContentRootPath);

            builder.AddJsonFile("json.json");

            AppConfiguration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var sections = AppConfiguration.GetSection("Users");
            var sectionUsers = sections.GetChildren();


            app.Run(async (context) =>
            {
                foreach (var item in sectionUsers)
                {
                    await context.Response.WriteAsync($"<br>Company: {item.Key}:{item.GetSection("Number").Value}</br>");
                }

            });
        }
    }
}
