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
    
    public async Task<IActionResult> Index()
    {
        
        List<Slider> sliders =await _context.Sliders
            .OrderBy(s=>s.Order)
            .Where(s => !s.isDeleted)
            .Take(2)
            .ToListAsync();
        
        List<Product>products= await _context.Products
            .Where(p=>!p.isDeleted)
            .Include(p=>p.ProductImages.Where(pi => !pi.IsPrimary!=null))
            .ToListAsync();
        
        HomeVM homeVM = new()
        {
            Sliders = sliders,
            Products=products
        };

        return View(homeVM);
    }
    
}