using FrontToBackSqlConnection.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("Server=localhost,1433;Database=FrontToBackDb;User Id=sa;Password=Parol123456!;TrustServerCertificate=True");
});

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();