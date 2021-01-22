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
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await _userManager.FindByNameAsync("Deus");
            List<AppUser> users = _userManager.Users.ToList();
            users.Remove(appUser);

            return View(users);
        }

        public async Task<IActionResult> AddAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                var removeResult = await _userManager.RemoveFromRoleAsync(appUser, "Subject");
                var result = await _userManager.AddToRoleAsync(appUser, "Imperator");
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> RemoveAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null && appUser.UserName != "Deus")
            {
                var result = await _userManager.RemoveFromRoleAsync(appUser, "Imperator");
                var addResult = await _userManager.AddToRoleAsync(appUser, "Subject");
                if (result != null)
                {

                    return RedirectToAction("Index");
                }
            }


            return RedirectToAction("Index");

        }
    }
}
