using System.Diagnostics;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        
        List<Slider> sliders = _context.Sliders
            .OrderBy(s=>s.Order)
            .Where(s => !s.isDeleted)
            .Take(2)
            .ToList();
        
        List<Product>products=_context.Products
            .Where(p=>!p.isDeleted)
            .Include(p=>p.ProductImages)
            .ToList();
        
        HomeVM homeVM = new()
        {
            Sliders = sliders,
            Products=products
        };

        return View(homeVM);
    }
    
}