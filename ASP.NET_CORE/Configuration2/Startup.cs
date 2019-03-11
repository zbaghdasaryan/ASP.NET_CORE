using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration2
{
    public class Startup
    {
        public IConfiguration appConfig { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "ApplicationName", null },
                { "EnvironmentName", null}
            });
            appConfig = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            appConfig["ApplicationName"] = env.ApplicationName;
            appConfig["EnvironmentName"] = env.EnvironmentName;

            string appName = $"<br>ApplicationName: {appConfig["ApplicationName"]}</br>";
            string envName = $"<br>EnvironmentName: {appConfig["EnvironmentName"]}<br>";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(appName + envName + env.WebRootPath);
                
            });
        }
    }
}
