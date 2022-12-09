using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Manage.ViewModels.Account;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                UserName = registerVM.UserName
            };

            //if (await _userManager.Users.AnyAsync(u => u.NormalizedUserName == registerVM.UserName.Trim().ToUpperInvariant()))
            //{
            //    ModelState.AddModelError("UserName","This username is already exists");
            //    return View(registerVM);
            //}

            //  if (await _userManager.Users.AnyAsync(u => u.NormalizedEmail == registerVM.Email.Trim().ToUpperInvariant()))
            //   {
            //        ModelState.AddModelError("Email","This email is already exists");
            //        return View(registerVM);
            //   }

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password); // methoddan qayidan neticeni tutmaq ucun (identity)

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");


            //return RedirectToAction("Index", "Dashboard", new { area = "manage" });
            return RedirectToAction("login");
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(loginVM);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =  await _signInManager.CheckPasswordSignInAsync(appUser, loginVM.Password, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(loginVM);
            }

            signInResult = await _signInManager.PasswordSignInAsync(appUser,loginVM.Password,loginVM.RemindMe,true);

                //if (signInResult.IsLockedOut)
                //{
                //    ModelState.AddModelError("", appUser.AccessFailedCount.ToString());
                //    return View(loginVM);
                //}            
            return RedirectToAction("Index", "Dashboard", new { area = "manage" });
        }

        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Email = "superadmin@protonmail.com",
        //        Name = "admin",
        //        UserName = "superadmin"
        //    };


        //    await _userManager.CreateAsync(appUser, "Admin1234");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Ok();
        //}

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}

        public IActionResult Index()
        {
            return View();
        }

    }
}
