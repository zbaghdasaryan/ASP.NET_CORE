using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
/*
ASP.NET Core поддерживает спецификацию OWIN (Open Web Interface for .NET), 
которая позволяет отвязать веб-приложение от конкретного веб-сервера и по 
сути создать самохостирующееся приложение.
*/
namespace OWIN
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(pipeline =>
            {
                pipeline(next => SendResponseAsync);
            });
        }
        public Task SendResponseAsync(IDictionary<string, object> environment)
        {
            // определяем ответ
            string responseText = "Hello ASP.NET Core";
            // кодируем его в массив байтов
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            // получаем поток ответа
            var responseStream = (Stream)environment["owin.ResponseBody"];
            // отправка ответа
            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
        /*
        Например, используем заголовки для отправки ответа в формате html.Для этого изменим метод SendResponseAsync:
        
        public Task SendResponseAsync(IDictionary<string, object> environment)
        {
            // получаем заголовки запроса
            var requestHeaders = (IDictionary<string, string[]>)environment["owin.RequestHeaders"];
            // получаем данные по User-Agent
            string responseText = requestHeaders["User-Agent"][0];
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            var responseStream = (Stream)environment["owin.ResponseBody"];

            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            */
    }
}

