using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowShoppingApp", policy =>
        policy.WithOrigins("https://localhost:6333") //shopping.com
            .AllowAnyMethod()
    );
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseRouting();
app.UseCors("AllowShoppingApp"); // ��������� CORS ��������� �������� "AllowShoppingApp" �� ���������
//app.UseCors(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
