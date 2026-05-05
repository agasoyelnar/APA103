using _26_DynamicPropertiesViewModel.HomeModels;
using _26_DynamicPropertiesViewModel.Models;
using Microsoft.AspNetCore.Mvc;
using HomeVM = _26_DynamicPropertiesViewModel.HomeModels.HomeVM;

namespace _26_DynamicPropertiesViewModel.Controllers;

public class HomeController:Controller
{ 
    List<Students> students = new List<Students>
    {
        new Students { Id = 1, Name = "Ruad", Age = 20 },
        new Students { Id = 2, Name = "Gunel", Age = 19 },
        new Students { Id = 3, Name = "Aysu", Age = 20 }
    };

    private List<Teacher> teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Name = "Ali", Salary = 300 },
        new Teacher { Id = 2, Name = "Eyyub", Salary = 200 }
    };
    
    
    public IActionResult Index()
    {
        // ViewBag.Students = students;
        // ViewData["Students"] = students;
        // TempData["Name"] = "Elnar";


        HomeVM homeVM = new()
        {
            Teachers = teachers,
            Students = students,
        };
        
        
        return View(homeVM);
    }

    public IActionResult Details(int id)
    {
        return View(students[id]);
    }
    

    [Route("korporative-satislar")]
    public IActionResult CorporativeSales()
    {
        return View();
    }
}

