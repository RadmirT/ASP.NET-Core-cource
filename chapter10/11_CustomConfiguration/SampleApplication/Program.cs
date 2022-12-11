using CustomConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    config.Sources.Clear();
    config.AddXmlFile("baseconfig.xml");

    IConfiguration partialConfig = config.Build();
    string filename = partialConfig["SettingsFile"];
    config.AddJsonFile(filename)
        .AddEnvironmentVariables();
});

builder.Services.Configure<CurrencyOptions>(builder.Configuration.GetSection("Currencies"));
builder.Services.Configure<CurrencyOptions>(options => options.Currencies = new string[] { "GBP", "USD" });

// Add services to the container.
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
