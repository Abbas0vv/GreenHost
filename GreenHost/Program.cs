

using GreenHost.Database;
using GreenHost.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TeamMemberRepository>();

builder.Services.AddDbContext<GreenHostDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
