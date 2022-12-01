using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using SampleApplication.ServicesLayer;
using SampleApplication.Settings;
using StoreViewerApplication;



//var builder = WebApplication.CreateBuilder(args);

var builder = WebApplication.CreateBuilder();


//builder.Host.ConfigureAppConfiguration((context, config) =>
//{
//    config.Sources.Clear(); // ������� �����������, ����������� �� ��������� � CreateDefaultBuilder
//    config.AddJsonFile("appsettings.json", optional: true); // ��������� ���������� ������������ JSON, ������������ ��� ����� ������������
//});

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    config.Sources.Clear(); // ������� �����������, ����������� �� ��������� � CreateDefaultBuilder
    config.AddJsonFile("sharedSettings.json", optional: true)  //��������� ������������ �� ������� ����� ������������ JSON ����� ������ appsettings.json
        .AddJsonFile("appsettings.json", optional: true)
        .AddEnvironmentVariables();  //��������� ���������� ��������� ������ � �������� ���������� ������������
    if (context.HostingEnvironment.IsDevelopment())
    {
        config.AddUserSecrets(Assembly.GetEntryAssembly(), optional:true);
    }

});



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<MapSettings>(builder.Configuration.GetSection("MapSettings"));
builder.Services.Configure<AppDisplaySettings>(builder.Configuration.GetSection("AppDisplaySettings"));
builder.Services.Configure<List<Store>>(builder.Configuration.GetSection("Stores"));
builder.Services.AddSingleton<MapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// var secret = app.Configuration["secretKey"];

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


