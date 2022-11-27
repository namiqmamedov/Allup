using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels.Shop;

namespace WebApplication1.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Search(int? id,string search)
        {
            IEnumerable<ProductListVM> products = products = await _context.Products
                    .Where(
                    p => id != null ?
                    p.CategoryId == id : true &&
                    p.Title.ToLower().Contains(search.ToLower()) ||
                    p.Brand.Name.ToLower().Contains(search.ToLower()))
                    .OrderByDescending(p=>p.Id)
                    .Take(3)
                    .Select(x=> new ProductListVM
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Image = x.MainImage
                    })
                    .ToListAsync();

            //List<ProductListVM> productListVMs = new List<ProductListVM>();

            //foreach (Product product in products)
            //{
            //    ProductListVM productListVM = new ProductListVM
            //    {
            //        Id = product.Id,
            //        Title = product.Title,
            //        Image = product.MainImage
            //    };

            //    productListVMs.Add(productListVM);

            //}

            //if (id != null)
            //{
            //    products = await _context.Products
            //        .Where(
            //        p => p.CategoryId == id &&
            //        p.Title.ToLower().Contains(search.ToLower()) ||
            //        p.Brand.Name.ToLower().Contains(search.ToLower())).ToListAsync();
            //}
            //else
            //{
            //    products = await _context.Products
            //        .Where(p=>
            //        p.Title.ToLower().Contains(search.ToLower()) ||
            //        p.Brand.Name.ToLower().Contains(search.ToLower())).ToListAsync();
            //}

            return PartialView("_SearchPartial", products);
        }



        public async Task<IActionResult> Modal(int? id)
        {
            Product product = await _context.Products.Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            return PartialView("_ProductModalPartial",product);
        }

    }
}
