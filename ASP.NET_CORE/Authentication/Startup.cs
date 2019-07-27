using AuthApp.Models; // пространство имен контекста данных UserContext
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
 
namespace AuthApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

            /* Для установки аутентификации с помощью куки в методе ConfigureServices в вызов services.AddAuthentication 
               передается значение CookieAuthenticationDefaults.AuthenticationScheme. Далее с помощью метода AddCookie() 
               настраивается аутентификация. По сути в этом методе производится конфигурация объекта CookieAuthenticationOptions,
               который описывает параметры аутентификации с помощью кук. В частности, в данном случае использовано одно свойство 
               CookieAuthenticationOptions - LoginPath. Это свойство устанавливает относительный путь, по которому будет 
               перенаправляться анонимный пользователь при доступе к ресурсам, для которых нужна аутентификация.
               И чтобы аутентификация была встроена в конвейер обработки запроса, в методе Configure вызывается компонент 
               middleware app.UseAuthentication().*/

            // установка конфигурации подключения

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
