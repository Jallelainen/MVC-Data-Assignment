using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Data_Assignment.Models.Identity;
using MVC_Data_Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //else if (result.IsLockedOut)
            //{

            //}

            loginViewModel.NoticeMessage = "Failed to login";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = loginViewModel.UserName;
                var result = await _userManager.CreateAsync(appUser, loginViewModel.Password);

                if (result.Succeeded)
                {

                }
                else
                {
                    loginViewModel.NoticeMessage = "Failed to create new account";
                    return View();
                }
            }

            loginViewModel.NoticeMessage = "Failed to create new account";
            return View();
        }
    }
}
