var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Map("/ping", (IApplicationBuilder branch) =>
{
    branch.UseStaticFiles();

    branch.Run(async (HttpContext context) =>
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("pong");
    });
});

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(
        DateTimeOffset.UtcNow.ToString());
});
app.Run();