using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id not a null");
            }

            Category category = await _context.Categories
                .Include(c=>c.Children)
                .FirstOrDefaultAsync(c => c.IsDeleted == false && c.IsMain && c.Id == id);

            if (category == null)
            {
                return NotFound("Id not correct");
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.Categories = await _context.Categories
                .Where(c => c.IsDeleted == false && c.IsMain)
                .ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Name.ToLower() == category.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This Name '{category.Name}' Already Exists ");
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
                    ModelState.AddModelError("File", "Maximum size is 24096 kb");
                    return View(category);
                }

                string fileName = Guid.NewGuid().ToString()+"-" +category.File.FileName;

                string path = @"C:\Users\ACER\Desktop\New folder\WebApplication1\wwwroot\assets\images\" + fileName;
                
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await category.File.CopyToAsync(fileStream);
                }
                category.ParentId = null;
                category.Image = fileName;
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Ust Category Secilmelidir");
                    return View(category);
                }
                if (!await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.IsMain && c.Id == category.ParentId))
                {
                    ModelState.AddModelError("ParentId", "Category is not correct");
                    return View(category);
                }

                category.Image = null;
            }

            category.Name = category.Name.Trim();
            category.IsDeleted = false;
            category.CreatedAt = DateTime.Now;
            category.CreatedBy = "System";

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID not a null");
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (category == null)
            {
                return NotFound("ID not correct");
            }

            ViewBag.Categories = await _context.Categories
               .Where(c => c.IsDeleted == false && c.IsMain)
               .ToListAsync();

            return View(category);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            ViewBag.Categories = await _context.Categories
              .Where(c => c.IsDeleted == false && c.IsMain)
              .ToListAsync();   
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (id == null)
            {
                return BadRequest("ID not a null");
            }

            if (category.Id != id)
            {
                return BadRequest("Id not a null");
            }

            if (await _context.Categories.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == category.Name.ToLower().Trim() && c.Id != id))
            {
                ModelState.AddModelError("Name", $"This Name '{category.Name}' Already Exists ");
                return View(category);
            }

            Category existedCategory = await _context.Categories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (existedCategory == null)
            {
                return NotFound("ID not correct");
            }

            if (category.IsMain)
            {
                if (existedCategory.Image == null && category.File == null)
                {
                    ModelState.AddModelError("File", "Error");
                    return View(category);
                }

                if (category.File != null)
                {
                    if (category.File.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", ".jpg or .jpeg");
                        return View(category);
                    }

                    if (category.File.Length > 24096)
                    {
                        ModelState.AddModelError("File", "Maximum size is 24096 kb");
                        return View(category);
                    }


                    //string path = @"C:\Users\ACER\Desktop\New folder\WebApplication1\wwwroot\assets\images\";
                    string path = Path.Combine(_env.WebRootPath + @"\assets\images\");

                    if (System.IO.File.Exists(Path.Combine(path,existedCategory.Image)))
                    {
                        System.IO.File.Delete(Path.Combine(path, existedCategory.Image));
                    }

                    string fileName = Guid.NewGuid().ToString() + "-" + category.File.FileName;
                    
                    string fullpath = Path.Combine(path,fileName);

                    using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                    {
                        await category.File.CopyToAsync(fileStream);
                    }

                    existedCategory.ParentId = null;
                    existedCategory.Image = fileName;
                }
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Ust Category Secilmelidir");
                    return View(category);
                }
                if (!await _context.Categories.AnyAsync(c => c.IsDeleted == false && c.IsMain && c.Id == category.ParentId))
                {
                    ModelState.AddModelError("ParentId", "Category is not correct");
                    return View(category);
                }

                existedCategory.Image = null;
                existedCategory.ParentId =  category.ParentId;

            }
                existedCategory.IsMain = category.IsMain;
                existedCategory.Name = category.Name.Trim();
                existedCategory.UpdatedAt = DateTime.Now;
                existedCategory.UpdatedBy = "System";

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID not a null");
            }

            Category category = await _context.Categories
                .Include(c => c.Products.Where(p => p.IsDeleted == false))
                .Include(c => c.Children.Where(p=> p.IsDeleted == false))
                .FirstOrDefaultAsync(c=> c.IsDeleted == false && c.Id == id);

            if (category == null)
            {
                return NotFound("Id not correct");
            }

            if ((category.Products != null && category.Products.Count() > 0) || (category.Children != null && category.Children.Count() > 0))
            {
                TempData["Error"] = $"Id = {id} li category siline bilmez";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
