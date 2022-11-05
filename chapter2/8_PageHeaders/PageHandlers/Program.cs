using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PageHandlers.ServicesLayer.Search;

namespace PageHandlers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<ISearchService, SearchService>();
            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.Run();

        }
    }
}
