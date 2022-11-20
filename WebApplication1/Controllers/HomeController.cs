using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                Categories = await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync()

            };

            return View(homeVM);
        }
    }
}
