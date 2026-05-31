using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.Utilities.Enum;
using FrontToBackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize(Roles = "Admin,Moderator,Member")]
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders
            .Where(s => !s.isDeleted)
            .ToListAsync();
        
        return View(sliders);
    }

    [Authorize(Roles = "Admin,Moderator")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
    {
        if (!ModelState.IsValid) return View();
        
        if (!sliderCreateVM.Photo.CheckFileType("image/"))
        {
            ModelState.AddModelError("Photo","File is incorret!");
            return View();
        }

        if (!sliderCreateVM.Photo.CheckFileSize(FileSize.MB,2))
        {
            ModelState.AddModelError("Photo","File is too large!");
            return View();
        }

        Slider slider = new()
        {
            Title = sliderCreateVM.Title,
            SubTitle = sliderCreateVM.SubTitle,
            Desc = sliderCreateVM.Desc,
            Order = sliderCreateVM.Order,
            Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images")
        };
        
        
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || id<1) return BadRequest();
        Slider? slider=await _context.Sliders.Where(s=>!s.isDeleted).FirstOrDefaultAsync(s=>s.Id==id);
        if (slider is null) return NotFound();

        slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
        _context.Remove(slider);
        await  _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Detail(int? id)
    {
        if (id is null || id < 1) return BadRequest();

        Slider? slider = await _context.Sliders
            .Where(s => !s.isDeleted)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (slider is null) return NotFound();

        return View(slider);
    }
    
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Update(int? id)
    {
        if (id is null || id<1) return BadRequest();
        Slider? slider=await _context.Sliders.Where(s=>!s.isDeleted).FirstOrDefaultAsync(s=>s.Id==id);
        if (slider is null) return NotFound();

        SliderUpdateVM sliderUpdateVm = new()
        {
            Title = slider.Title,
            SubTitle = slider.SubTitle,
            Desc = slider.Desc,
            Order = slider.Order,
            Image = slider.Image,
        };
        return View(sliderUpdateVm);
    }
}