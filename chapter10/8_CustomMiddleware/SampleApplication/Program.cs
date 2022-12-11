using SampleApplication;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseMiddleware<SecurityHeadersMiddleware>();

app.Run(async context =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(
        DateTimeOffset.UtcNow.ToString());
});
app.Run();