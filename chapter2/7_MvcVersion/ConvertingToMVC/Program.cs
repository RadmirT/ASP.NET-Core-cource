using ConvertingToMVC.ServicesLayer.ToDo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ConvertingToMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IToDoService, ToDoService>();

            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(
                endpoints => {
                    endpoints.MapDefaultControllerRoute(); });
            app.Run();

        }
    }
}
