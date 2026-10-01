using Microsoft.EntityFrameworkCore;
using WebShopping.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DevConnection")
        ?? throw new InvalidOperationException("Connection string 'DevConnection' was not found.")
    : builder.Configuration.GetConnectionString("ProdConnection")
        ?? throw new InvalidOperationException("Connection string 'ProdConnection' was not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin",
    defaults: new { area = "Admin", controller = "Dashboard", action = "Index" }
);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
