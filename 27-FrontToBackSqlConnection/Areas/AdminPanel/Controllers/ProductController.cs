using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers;
[Area("AdminPanel")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ProductController(AppDbContext context,IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {
        List<ProductGetVM> productGetVMs = await _context.Products
            .Where(p => !p.isDeleted)
            .Include(p => p.ProductImages)
            .Include(p => p.Category)
            .Select(p => new ProductGetVM
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Price = p.Price,
                SKU = p.SKU,
                Image = p.ProductImages.FirstOrDefault().Image,
            })
            .ToListAsync();
        
         
        return View(productGetVMs);
    }

    public async Task<IActionResult> Create()
    {
        ProductCreateVM productCreateVM = new()
        {
            Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync()
        };
        return View(productCreateVM);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
    {
        productCreateVM.Categories = await _context.Categories.Where(c=>!c.isDeleted).ToListAsync();
        if  (!ModelState.IsValid) return View(productCreateVM);
        bool existsCategory = productCreateVM.Categories
            .Any(c=>c.Id == productCreateVM.CategoryId);
        if (!existsCategory)
        {
            ModelState.AddModelError(nameof(productCreateVM.CategoryId),"categories not found");
        }

        Product product = new()
        {
            Name = productCreateVM.Name,
            Price = productCreateVM.Price,
            Description = productCreateVM.Description,
            SKU = productCreateVM.SKU,
            CategoryId = productCreateVM.CategoryId.Value,
        };
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}