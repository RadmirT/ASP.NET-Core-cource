using Microsoft.Extensions.DependencyInjection;
using SampleApplication;
using SampleApplication.ServicesLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ServiceA>();
builder.Services.AddTransient<ServiceB>();

var app = builder.Build();


app.UseMiddleware<MyMiddleware>();

app.Run(async context =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(
        DateTimeOffset.UtcNow.ToString());
});
app.Run();