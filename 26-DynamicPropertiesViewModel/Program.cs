using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // app.MapControllerRoute(
        //     "Corporative",
        //     "corporative_satislar",
        //     new {controller="home", action="corporativesales"}
        // );
        
        
        app.MapControllerRoute(
            "default",
            "{controller=home}/{action=Index}/{id?}"
        );

        app.Run();
    }
}