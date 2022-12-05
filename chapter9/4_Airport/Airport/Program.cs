using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Airport.Authorization;
using Airport.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection")));


builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanEnterSecurity", policyBuilder
        => policyBuilder.RequireClaim(Claims.BoardingPassNumber));

    options.AddPolicy("CanAccessLounge", policyBuilder
        => policyBuilder.AddRequirements(
            new MinimumAgeRequirement(18),
            new AllowedInLoungeRequirement()
        ));
});

builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, FrequentFlyerHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, BannedFromLoungeHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, IsAirlineEmployeeHandler>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.Run();