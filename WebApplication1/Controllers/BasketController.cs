using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public object JsonConver { get; private set; }

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
                return BadRequest("Id don't a null");
            }

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            if (product == null)
            {
                return NotFound("Id Not Correct");
            }

            List<Product> products = new List<Product>();
            products.Add(product);


            string pro = JsonConvert.SerializeObject(product);

            HttpContext.Response.Cookies.Append("basket", pro);


            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> GetFromBasket()
        {
            string pro = HttpContext.Request.Cookies["basket"];

            List<Product> product = JsonConvert.DeserializeObject<List<Product>>(pro);

            return Json(product);
        }
    }
}
