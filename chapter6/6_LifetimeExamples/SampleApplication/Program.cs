using SampleApplication.ServicesLayer;

var builder = WebApplication.CreateBuilder(args);
// Принудительно выключаем проверку захваченных зависимостей
builder.Host
    .UseDefaultServiceProvider((context, options) =>
    {
        options.ValidateScopes = false;
        options.ValidateOnBuild = false;
    });

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<TransientRepository>();
builder.Services.AddTransient<TransientDataContext>();

builder.Services.AddScoped<ScopedRepository>();
builder.Services.AddScoped<ScopedDataContext>();

builder.Services.AddSingleton<SingletonRepository>();
builder.Services.AddSingleton<SingletonDataContext>();
builder.Services.AddSingleton<CapturingRepository>();

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
