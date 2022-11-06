using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RoutingExample.ServicesLayer.Products;

namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddHealthChecks();
            builder.Services.AddSingleton<ProductService>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting(); // Добавляем компонент маршрутизации (RoutingMiddleware)

            // Настраиваем EndpointMiddleware
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Регистрирует страницы Razor
                endpoints.MapHealthChecks("/healthz"); // Регистрирует конечную точку проверки работоспособности.
                
                // Регистрируем "особую" конечную точку.
                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.Run();
        }
    }
}
