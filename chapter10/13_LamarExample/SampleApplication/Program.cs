using System.Reflection;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLamar((context, registry) =>
{
    registry.Scan(_ =>
    {
        _.Assembly(Assembly.GetExecutingAssembly());
        _.WithDefaultConventions();
    });
    
}); // ¬ключаем использование Lamar

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
