using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _context;
    public ShopController(AppDbContext context)
    {
        _context = context;
    } 
    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products
            .Where(p => !p.isDeleted)
            .Include(p => p.ProductImages.Where(pi=>pi.IsPrimary!=null))
            .ToListAsync();
        
        ShopVM shopVM = new()
        {
            Products = products
        };
        return View(shopVM);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null || id < 1) return BadRequest();
        
        Product? product= await _context.Products
            .Where(p=>!p.isDeleted)
            .Include(p=>p.ProductImages)
            .Include(p=>p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        List<Product>relatedProducts= await _context.Products
            .Where(p=>!p.isDeleted)
            .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary!=null))
            .Where(p => p.CategoryId == product.CategoryId && p.Id!=id)
            .Take(4)
            .ToListAsync();
        
        if (product is null) return NotFound();
        
        DetailsVM detailsVM = new()
        {
            Product = product,
            RelatedProducts = relatedProducts
            
        };
        return View(detailsVM);
    }
}