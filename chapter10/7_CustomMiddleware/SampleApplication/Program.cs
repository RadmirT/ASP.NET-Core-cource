var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context,  next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-Content-Type-Options"] =
            "nosniff";
        return Task.CompletedTask;
    });
    await next();
});


app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(
        DateTimeOffset.UtcNow.ToString());
});
app.Run();