using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class SliderController : Controller
{
    
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    public SliderController(AppDbContext context,IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders
            .Where(s => !s.isDeleted)
            .ToListAsync();
        
        return View(sliders);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Slider slider)
    {
        if (!ModelState.IsValid) return View();
        
        if (!slider.Photo.ContentType.Contains("image/"))
        {
            ModelState.AddModelError(nameof(Slider.Photo),"File is incorret!");
            return View();
        }

        if (slider.Photo.Length > 2 * 1024 * 1024)
        {
            ModelState.AddModelError(nameof(Slider.Photo),"File is too large!");
            return View();
        }

        string fileName=string.Concat(Guid.NewGuid().ToString(), slider.Photo.FileName);
        string path =Path.Combine(_env.WebRootPath, "assets", "images", "website-images", fileName);

        FileStream fileStream = new FileStream(path, FileMode.Create);
        await slider.Photo.CopyToAsync(fileStream);
        fileStream.Close();
        slider.Image = fileName;
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}