using SampleApplication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    var endpoint = endpoints
        .CreateApplicationBuilder()
        .UseMiddleware<PingPongMiddleware>()
        .Build();
   
    endpoints.Map("/ping", endpoint);

    // endpoints.MapPingPong("/ping");

    //endpoints.MapGet("/ping", (HttpContext ctx) =>
    //    ctx.Response.WriteAsync("pong"));
});


app.Run();