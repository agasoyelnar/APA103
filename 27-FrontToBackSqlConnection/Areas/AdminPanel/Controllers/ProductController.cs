using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.Utilities.Enum;
using FrontToBackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
[Authorize(Roles = "Admin, Moderator")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ProductController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    [Authorize(Roles = "Admin,Moderator,Member")]
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
                Image = p.ProductImages.FirstOrDefault(p=>p.IsPrimary==true).Image,
            })
            .ToListAsync();


        return View(productGetVMs);
    }

    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Create()
    {
        ProductCreateVM productCreateVM = new()
        {
            Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync(),
            Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync(),
        };
        return View(productCreateVM);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
    {
        productCreateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
        productCreateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();

        if (!ModelState.IsValid) return View(productCreateVM);

        if (!productCreateVM.MainPhoto.CheckFileType("image/"))
        {
            ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is incorrect");
            return View(productCreateVM);
        }
        if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB,1))
        {
            ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size  less be than 2mb");
            return View(productCreateVM);
        }
        if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
        {
            ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is incorrect");
            return View(productCreateVM);
        }
        
        if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB,1))
        {
            ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size  less be than 2mb");
            return View(productCreateVM);
        }
        
        bool existsCategory = productCreateVM.Categories
            .Any(c => c.Id == productCreateVM.CategoryId);
        if (!existsCategory)
        {
            ModelState.AddModelError(nameof(productCreateVM.CategoryId), "categories not found");
            return View(productCreateVM);
        }

        if (productCreateVM.TagIds is not null)
        {
            bool exitsTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
            if (exitsTag)
            {
                ModelState.AddModelError(nameof(productCreateVM.TagIds), "tags not found");
                return View(productCreateVM);
            }
        }

        ProductImage mainImage = new()
        {
            Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath,"assets","images","website-images"),
            IsPrimary = true
        };
        ProductImage hoverImage = new()
        {
            Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath,"assets","images","website-images"),
            IsPrimary = false
        };

        Product product = new()
        {
            Name = productCreateVM.Name,
            Price = productCreateVM.Price,
            Description = productCreateVM.Description,
            SKU = productCreateVM.SKU,
            CategoryId = productCreateVM.CategoryId.Value,
            ProductImages = new List<ProductImage>{mainImage, hoverImage }
        };
        
        if (productCreateVM.TagIds is not null)
        {
            product.ProductTags = productCreateVM.TagIds.Select(tId => new ProductTag { TagId = tId }).ToList();
        }

        string info = string.Empty;
        if (productCreateVM.AdditionalPhotos is not null)
        {
            foreach (var file in productCreateVM.AdditionalPhotos)
            {
                if (!file.CheckFileType("image/"))
                {
                    info += $"<p>{file.FileName} type was not correct</p>";
                    continue;
                }
                if (!file.CheckFileSize(FileSize.KB,100))
                {
                    info += $"<p>{file.FileName} size was not correct</p>";
                    continue;
                }
            
                product.ProductImages.Add(new ProductImage
                {
                    Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                    IsPrimary=null
                });
            }
        }
        TempData["FileInfo"] = info;
        
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id < 1) return BadRequest();
        Product? existProduct =
            await _context.Products
                .Include(p=>p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id);
        if (existProduct == null) return NotFound();

        if (!ModelState.IsValid) return View();
        ProductUpdateVM productUpdateVM = new()
        {
            Name = existProduct.Name,
            Price = existProduct.Price,
            Description = existProduct.Description,
            SKU = existProduct.SKU,
            CategoryId = existProduct.CategoryId,
            TagIds = existProduct.ProductTags.Select(pt => pt.TagId).ToList(),
            Categories = await _context.Categories.ToListAsync(),
            Tags = await _context.Tags.ToListAsync(),
            ProductImages =  existProduct.ProductImages
        };

        return View(productUpdateVM);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
    {
        if (id == null || id < 1) return BadRequest();
        
        Product? existProduct = await _context.Products
            .Include(p=>p.ProductImages)
            .Include(p=>p.ProductTags)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (existProduct == null) return NotFound();
        
        productUpdateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
        productUpdateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();
        productUpdateVM.ProductImages = existProduct.ProductImages;
        
        if (!ModelState.IsValid) return View(productUpdateVM);

        
        if (productUpdateVM.MainPhoto is not null)
        {
            if (!productUpdateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File type is incorrect");
                return View(productUpdateVM);
            }
            if (!productUpdateVM.MainPhoto.CheckFileSize(FileSize.MB,1))
            {
                ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File size  less be than 2mb");
                return View(productUpdateVM);
            }
        }

        if (productUpdateVM.HoverPhoto is not null)
        {
            if (!productUpdateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File type is incorrect");
                return View(productUpdateVM);
            }
        
            if (!productUpdateVM.HoverPhoto.CheckFileSize(FileSize.MB,1))
            {
                ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File size  less be than 2mb");
                return View(productUpdateVM);
            }
        }
        
        bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
        if (!existCategory)
        {
            ModelState.AddModelError(nameof(productUpdateVM.CategoryId), "categories not found");
            return View(productUpdateVM);
        }

        if (productUpdateVM.TagIds is not null)
        {
            bool exitsTag = productUpdateVM.TagIds.Any(tagId => productUpdateVM.Tags.Exists(t => t.Id == tagId));
            if (!exitsTag)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "tags not found");
                return View(productUpdateVM);
            }
        }

        if (productUpdateVM.TagIds is null)
        {
            productUpdateVM.TagIds = new();
        }
        
        if (productUpdateVM.TagIds is not  null)
        {
            _context.ProductTags.RemoveRange(existProduct.ProductTags
                .Where(pTag => !productUpdateVM.TagIds
                    .Exists(tId => tId == pTag.TagId))
                .ToList());
        
            _context.ProductTags.AddRange(productUpdateVM.TagIds
                .Where(tId => !existProduct.ProductTags.Exists(pTag => pTag.TagId == tId))
                .ToList()
                .Select(tId => new ProductTag { TagId = tId, ProductId = existProduct.Id }));
        }

        if (productUpdateVM.MainPhoto is not null)
        {
            string fileName = await productUpdateVM.MainPhoto.CreateFile(_env.WebRootPath,"assets","images","website-images");
            ProductImage mainImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);
            
            mainImage.Image.DeleteFile(_env.WebRootPath,"assets","images","website-images");
            existProduct.ProductImages.Remove(mainImage);
            existProduct.ProductImages.Add(new ProductImage
            {
                Image = fileName,
                IsPrimary = true
            });
        }
        if (productUpdateVM.HoverPhoto is not null)
        {
            string fileName = await productUpdateVM.HoverPhoto.CreateFile(_env.WebRootPath,"assets","images","website-images");
            ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);
            
            hoverImage.Image.DeleteFile(_env.WebRootPath,"assets","images","website-images");
            existProduct.ProductImages.Remove(hoverImage);
            existProduct.ProductImages.Add(new ProductImage
            {
                Image = fileName,
                IsPrimary = false
            });
        }
        
        if (productUpdateVM.ImageIds is not null)
        {
            productUpdateVM.ImageIds = new List<int>();
        }
        
        var deleteImages =
            existProduct.ProductImages
                .Where(pi => productUpdateVM.ImageIds
                    .Exists(imgId => imgId == pi.Id )&& pi.IsPrimary==true)
                .ToList();
        deleteImages.ForEach(di=>di.Image.DeleteFile(_env.WebRootPath,"assets","images","website-images"));
        _context.ProductImages.RemoveRange(deleteImages);
        
        if (productUpdateVM.AdditionalPhotos is not null)
        {
            string info = string.Empty;
            foreach (var file in productUpdateVM.AdditionalPhotos)
            {
                if (!file.CheckFileType("image/"))
                {
                    info += $"<p>{file.FileName} type was not correct</p>";
                    continue;
                }
                if (!file.CheckFileSize(FileSize.KB,100))
                {
                    info += $"<p>{file.FileName} size was not correct</p>";
                    continue;
                }
            
                existProduct.ProductImages.Add(new ProductImage
                {
                    Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                    IsPrimary=null
                });
            }
            TempData["FileInfo"] = info;
        }
        
        existProduct.Name = productUpdateVM.Name;
        existProduct.Price = productUpdateVM.Price;
        existProduct.Description = productUpdateVM.Description;
        existProduct.SKU = productUpdateVM.SKU;
        existProduct.CategoryId = productUpdateVM.CategoryId.Value;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || id<1) return BadRequest();
        Product? product=await _context.Products
            .Where(s=>!s.isDeleted)
            .Include(p=>p.ProductImages)
            .FirstOrDefaultAsync(p=>p.Id==id);
        if (product is null) return NotFound();

        if (product.ProductImages is not null)
        {
            foreach (ProductImage productImage in product.ProductImages)
            {
                productImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            }
        }       
        _context.Remove(product);
        await  _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> Detail(int? id)
    {
        if (id is null || id < 1) return BadRequest();

        Product? product = await _context.Products
            .Include(p=>p.ProductImages)
            .Where(s => !s.isDeleted)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (product is null) return NotFound();

        return View(product);
    }
}