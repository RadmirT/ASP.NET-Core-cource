using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();
            app.UseWelcomePage();
            app.Run();
        }
    }
}