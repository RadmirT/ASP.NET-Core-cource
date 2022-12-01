using FilterPipelineExample.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//builder.Services.AddRazorPages()
//    .AddMvcOptions(options =>
//    {
//        options.Filters.Add<LogResourceFilter>();
//    });

builder.Services.AddControllers(options =>
{
    /*
    options.Filters.Add(new LogResourceFilter());
    options.Filters.Add(typeof(LogResourceFilter));
    options.Filters.Add<LogResourceFilter>();
    /**/

    //options.Filters.Add(new OrderedResourceFilter(3));

    //options.Filters.Add(new GlobalLogAsyncActionFilter());
    //options.Filters.Add(new GlobalLogAsyncPageFilter());
    //options.Filters.Add(new GlobalLogAsyncAuthorizationFilter());
    //options.Filters.Add(new GlobalLogAsyncExceptionFilter());
    //options.Filters.Add(new GlobalLogAsyncResourceFilter());
    //options.Filters.Add(new GlobalLogAsyncResultFilter());
    //options.Filters.Add(new GlobalLogAsyncAlwaysRunResultFilter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
