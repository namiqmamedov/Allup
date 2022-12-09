using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize] // session olub olmadigini yoxluyur
    public class DashboardController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }
    }
}
