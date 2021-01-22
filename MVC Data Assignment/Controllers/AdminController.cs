using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Data_Assignment.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Controllers
{
    [Authorize(Roles = "Imperator")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> AddAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                var result = await _userManager.AddToRoleAsync(appUser, "Imperator");
                if (result != null)
                {
                    ViewBag.Msg = "Operation Succeeded, Admin Added";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Msg = "Operation Failed";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> RemoveAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null && appUser.UserName != "Deus")
            {
                var result = await _userManager.RemoveFromRoleAsync(appUser, "Imperator");
                if (result != null)
                {
                    ViewBag.Msg = "Operation Succeeded, Admin Removed";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Msg = "Operation Failed";
            return RedirectToAction("Index");

        }
    }
}
