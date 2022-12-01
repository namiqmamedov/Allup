using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ComponentViewModels.Header;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels.Basket;

namespace WebApplication1.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(HeaderVM headerVM)
        {
        //    string basket = HttpContext.Request.Cookies["basket"];
        //    List<BasketVM> basketVMs = null; // basket deyeri yoxdusa bost list versin

        //    if (!string.IsNullOrWhiteSpace(basket))
        //    {
        //        basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
        //    }
        //    else
        //    {
        //        basketVMs = new List<BasketVM>(); // bos list versin
        //    }

        //    foreach (BasketVM basketVM in basketVMs)
        //    {
        //        Product product = await _context.Products.
        //            FirstOrDefaultAsync(p => p.Id == basketVM.Id && p.IsDeleted == false);

        //        basketVM.Title = product.Title;
        //        basketVM.Image = product.MainImage;
        //        basketVM.ExTax = product.ExTax;
        //        basketVM.Price = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price;
        //    }


        //    Dictionary<string,string> settings = await _context.Settings
        //        .ToDictionaryAsync(s => s.Key, s => s.Value);

        //    HeaderVM headerVM = new HeaderVM
        //    {
        //        Settings = await _context.Settings
        //        .ToDictionaryAsync(s => s.Key, s => s.Value),
        //        Categories = await _context.Categories.
        //        Include(c => c.Children).
        //        Where(c => c.IsDeleted == false && c.IsMain).
        //        ToListAsync(),
        //        BasketVMs = basketVMs       
        //};

            return View(await Task.FromResult(headerVM));
        }
    }
}
