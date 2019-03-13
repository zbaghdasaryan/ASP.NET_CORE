using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetSection1
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
            IConfigurationSection sections = AppConfiguration.GetSection("Company");
            string companyName = sections.GetSection("Name").Value;
            string companyDevelopers = sections.GetSection("Employees").Value;

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<br>Company: {companyName}.</br>");
                await context.Response.WriteAsync($"<br>Developers: {companyDevelopers}.</br>");
            });
        }
    }
}
