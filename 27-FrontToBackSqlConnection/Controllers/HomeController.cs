using System.Diagnostics;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBackSqlConnection.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    
    
    // List<Slider> _sliders = new List<Slider>
    // {
    //     new Slider
    //     { 
    //         Title = "Basliq-1", SubTitle = "Komekci basliq 1", Desc = "Gullerden qalmadi", Image = "1-1-524x617.png",Order = 3,isDeleted =  false
    //     },
    //     new Slider
    //     {
    //         Title = "Basliq-2", SubTitle = "Komekci basliq 2", Desc = "Mohtesem endirim ", Image = "1-2-524x617.png",Order = 2,isDeleted =  true
    //     },
    //     new Slider
    //     {
    //         Title = "Basliq-3", SubTitle = "Komekci basliq3", Desc = "Yeni Guller", Image = "new flower.jpg",Order = 1,isDeleted =  false
    //     },
    // };
    
    public IActionResult Index()
    {
        // _context.AddRange(_sliders);
        // _context.SaveChanges();
        
        List<Slider> sliders = _context.Sliders
            .OrderBy(s=>s.Order)
            .Where(s => !s.isDeleted)
            .Take(2)
            .ToList();
        
        HomeVM homeVM = new()
        {
            Sliders = sliders
        };

        return View(homeVM);
    }
    
}