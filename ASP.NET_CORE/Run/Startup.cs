﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Run
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //public delegate Task RequestDelegate(HttpContext context);
        Task Handler(HttpContext context)
        {
            string host = context.Request.Host.Value;
            string path = context.Request.Path;
            string query = context.Request.QueryString.Value;
            context.Response.ContentType = "text/html; charset=UTF-8";
            return context.Response.WriteAsync($"<h3>host: {host}</h3>" + $"<h3>path: {path}</h3>" + $"<h3>query: {query}</h3>" + "Hello World");
        }

        public void Configure(IApplicationBuilder app)
        {

            //app.Run(async (context) =>
            //{
            //    string host = context.Request.Host.Value;
            //    string path = context.Request.Path;
            //    string query = context.Request.QueryString.Value;

            //    context.Response.ContentType = "text/html; charset=UTF-8";
            //    await context.Response.WriteAsync($"<h3>host: {host}</h3>" + $"<h3>path: {path}</h3>" + $"<h3>query: {query}</h3>" + "Hello World");
            //});

            app.Run(Handler);


            //{
            //    int x = 5;
            //    int y = 8;
            //    int z = 0;
            //    app.Use(async (context, next) =>
            //    {
            //        z = x * y;
            //        await next.Invoke();
            //    });

            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync($"x * y = {z}");
            //    });
            //}
        }
    }
}
