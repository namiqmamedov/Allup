using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductTag).ThenInclude(pt => pt.Tag)
                .Where(p => p.IsDeleted == false)
                .ToListAsync();


            return View(products);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {                          // eger sehfdirse viewa qayidir
                return View(product);
            }

            if (!await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Id == product.CategoryId ))
            {
                ModelState.AddModelError("CategoryId", "Category is not correct");
                return View(product);
            }

            if (product.BrandId == null)
            {
                ModelState.AddModelError("BrandId", "Brand is not correct");
                return View(product);
            }


            if (!await _context.Brands.AnyAsync(c => c.IsDeleted == false && c.Id == product.BrandId))
            {
                ModelState.AddModelError("BrandId", "Brand is not correct");
                return View(product);
            }

            List<ProductTag> productTags = new List<ProductTag>();

            foreach (int tagId in product.TagIds)
            {
                if (product.TagIds.Where(t=>t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "A Tag can only be selected once");
                    return View(product);   // eyni tag 1 den artiq secile bilmez
                }

                if (!await _context.Tags.AnyAsync(c => c.IsDeleted == false && c.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correct");
                    return View(product);
                }

                ProductTag productTag = new ProductTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(+4),
                    CreatedBy = "System",
                    IsDeleted = false,
                    TagId = tagId
                };

                productTags.Add(productTag);

            }

            product.ProductTag = productTags;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }


        [HttpGet]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.TagIds = await _context.ProductTags.Where(pt => pt.ProductId == id).Select(t=>t.TagId).ToListAsync();

            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Product product) 
        {
            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {                          
                return View(product);
            }

            Product existedProduct = await _context.Products.Include(c=>c.ProductTag).FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            _context.ProductTags.RemoveRange(existedProduct.ProductTag);


            List<ProductTag> productTags = new List<ProductTag>();

            foreach (int tagId in product.TagIds)
            {
                if (product.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "A Tag can only be selected once");
                    return View(product);   // eyni tag 1 den artiq secile bilmez
                }

                if (!await _context.Tags.AnyAsync(c => c.IsDeleted == false && c.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correct");
                    return View(product);
                }

                ProductTag productTag = new ProductTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(+4),
                    CreatedBy = "System",
                    IsDeleted = false,
                    TagId = tagId
                };

                productTags.Add(productTag);

            }

            existedProduct.ProductTag = productTags;
            existedProduct.Title = product.Title;

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }
}
