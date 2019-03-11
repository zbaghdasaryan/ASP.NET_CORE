using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration1
{
    public class Startup
    {
        public IConfiguration appConfig { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string> { { "Name", "Poghos" },
                { "Surname", "Matevosyan"}});
            appConfig = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            string name = $"<br>name: {appConfig["Name"]}</br>";
            string surname = $"<br>surname: {appConfig["surname"]}<br>";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(name +surname);
            });
        }
    }
}
