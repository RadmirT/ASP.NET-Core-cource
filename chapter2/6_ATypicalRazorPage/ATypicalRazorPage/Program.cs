using ATypicalRazorPage.ServicesLayer.ToDo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ATypicalRazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IToDoService, ToDoService>();

            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
            app.Run();

        }
    }
}
