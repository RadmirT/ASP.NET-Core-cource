using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddHealthChecks();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting(); // Добавляем компонент маршрутизации (RoutingMiddleware)

            // Настраиваем EndpointMiddleware
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Регистрирует страницы Razor
                endpoints.MapDefaultControllerRoute(); // Регистрирует контроллеры MVC
            });

            app.Run();
        }
    }
}
