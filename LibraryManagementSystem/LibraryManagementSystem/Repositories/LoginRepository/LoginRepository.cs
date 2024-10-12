using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.LoginRepository
{
    public class LoginRepository : Controller,ILoginRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public LoginRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> SaveLogin(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByNameAsync(userLoginViewModel.UserName);
                if (appUser != null)
                {
                    bool ok = await userManager.CheckPasswordAsync(appUser, userLoginViewModel.Password);
                    if (ok)
                    {
                        await signInManager.SignInAsync(appUser, userLoginViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Username or password wrong");
            }
            return View("Login", userLoginViewModel);
        }

        public async Task<IActionResult> SignOut(string ControllerName)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", ControllerName);
        }
    }
}
