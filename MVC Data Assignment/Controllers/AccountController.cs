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
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    loginViewModel.NoticeMessage = "Failed to login";
                    return View(loginViewModel);
                }
            }
            else
            {
                loginViewModel.NoticeMessage = "Failed to login";
                return View(loginViewModel);
            } 

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            return View(signUpViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = signUpViewModel.UserName;
                appUser.FirstName = signUpViewModel.FirstName;
                appUser.LastName = signUpViewModel.LastName;
                appUser.BirthDate = signUpViewModel.BirthDate
                    ;
                var result = await _userManager.CreateAsync(appUser, signUpViewModel.Password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Subject");
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    signUpViewModel.NoticeMessage = "Failed to create new account";
                    return View(signUpViewModel);
                }
            }

            signUpViewModel.NoticeMessage = "Failed to create new account";
            return View(signUpViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
