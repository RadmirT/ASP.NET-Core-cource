var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/branch", b =>
{
    b.Run(async context =>
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync($"Path:\"{context.Request.Path}\"\nPathBase:\"{context.Request.PathBase}\"");
    });
});

app.Run(async context =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync($"Path:\"{context.Request.Path}\"\nPathBase:\"{context.Request.PathBase}\"");
});
app.Run();