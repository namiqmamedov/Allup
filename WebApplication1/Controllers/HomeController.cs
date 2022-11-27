using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels.Home;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //List<Setting> settings = _context.Settings.ToList();
            //ViewBag.Settings = settings;
            //List<Slider> sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Categories = await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync(),
                NewArrival = await _context.Products.Where(p => p.IsDeleted == false && p.IsNewArrival == true).ToListAsync(),
                BestSeller = await _context.Products.Where(p => p.IsDeleted == false && p.IsBestSeller == true).ToListAsync(),
                Featured = await _context.Products.Where(p => p.IsDeleted == false && p.IsFeatured == true).ToListAsync()        
            };

            return View(homeVM);
        }


        // obyekti cookiede saxlamaq ucun
        public async Task<IActionResult> SetCookie()
        {
            Product product = await _context.Products.FirstAsync();

            string cookie = JsonConvert.SerializeObject(product);

            HttpContext.Response.Cookies.Append("basket", cookie);

            return Ok();
        }


        public async Task<IActionResult> GetCookie()
        {
            string cookie = HttpContext.Request.Cookies["basket"];

            return Json(cookie);
        }

        //public async Task<IActionResult> SetCookie()
        //{
        //    HttpContext.Response.Cookies.Append("ZIP","Cookie");

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> GetCookie()
        //{
        //    return Content(HttpContext.Request.Cookies["ZIP"]);
        //}

        //public async Task<IActionResult> SetSession()
        //{
        //    HttpContext.Session.SetString("ZIP", "Session");

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> GetSession()
        //{
        //    //HttpContext.Session.GetString("ZIP", "Session");

        //    return Content(HttpContext.Session.GetString("ZIP"));
        //}
    }
}
