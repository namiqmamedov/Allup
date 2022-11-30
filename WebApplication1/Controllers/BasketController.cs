using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels.Basket;


namespace WebApplication1.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id not a null");
            }

            //Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            if (!await _context.Products.AnyAsync(p=>p.IsDeleted == false && p.Id == id))
            {
                return NotFound("Id Not Correct");
            }

            string basket = HttpContext.Request.Cookies["basket"]; // cookie datasini vermesi ucun
                                                                   // basket deyerini stringe verir

            List<BasketVM> products = null;
            if (!string.IsNullOrWhiteSpace(basket)) // varsa eger cookie ye dussun deye
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                BasketVM basketVM = products.Find(p => p.Id == id);
                if (basketVM != null)
                {
                    basketVM.Count += 1;
                }
                else
                {
                    basketVM = new BasketVM
                    {
                        Id = (int)id, //nullable olaraq yox int olaraq casting elesin deye
                        Count = 1
                    };

                    products.Add(basketVM);
                }
            }

            else  // bele bir basket yoxdursa
            {
                products = new List<BasketVM>();
                BasketVM basketVM = new BasketVM
                {
                    Id = (int)id,
                    Count = 1
                };
                products.Add(basketVM);
            }


            basket = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("basket", basket);

            foreach (BasketVM basketVM in products)
            {
                Product product =  await _context.Products.
                    FirstOrDefaultAsync(p => p.Id == basketVM.Id && p.IsDeleted == false);

                basketVM.Title = product.Title;
                basketVM.Image = product.MainImage;
                basketVM.ExTax = product.ExTax;
                basketVM.Price = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price;
            }

            return PartialView("_BasketListPartial",products);
        }

        //public async Task<IActionResult> GetFromBasket()
        //{
        //    string basket = HttpContext.Request.Cookies["basket"];

        //    List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

        //    return Json(products);
        //}
    }
}
