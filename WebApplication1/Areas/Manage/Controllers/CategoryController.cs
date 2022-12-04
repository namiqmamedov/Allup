using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories
                .Include(c=>c.Products)
                .Where(c => c.IsDeleted == false && c.IsMain).
                ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories
                .Where(c => c.IsDeleted == false && c.IsMain)
                .ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category,IFormFile file)
        {
            ViewBag.Categories = await _context.Categories
                .Where(c => c.IsDeleted == false && c.IsMain)
                .ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.IsMain)
            {
                if (category.File == null)
                {
                    ModelState.AddModelError("File", "Error");
                    return View(category);
                }
                if (category.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", ".jpg or .jpeg");
                    return View(category);
                }
                if (category.File.Length > 24096)
                {
                    ModelState.AddModelError("File", "Maximum size is 4096 kb");
                    return View(category);
                }

                string path = @"C:\Users\ACER\Desktop\New folder\WebApplication1\wwwroot\assets\images\" + category.File.FileName;
                
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await category.File.CopyToAsync(fileStream);
                }
            }



            return Content("");
        }
     }
}
