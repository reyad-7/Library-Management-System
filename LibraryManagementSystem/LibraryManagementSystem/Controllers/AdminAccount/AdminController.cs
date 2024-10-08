using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.AdminAccount
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AdminRegistration()
        {
            return View("AdminRegistration");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> saveAdminRegistration(RegistrationModelView reg)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Address = reg.Address;
                appUser.UserName = reg.UserName;
                appUser.FullName = reg.FullName;
                appUser.PasswordHash = reg.Password;

                IdentityResult result = await userManager.CreateAsync(appUser, reg.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)

                        ModelState.AddModelError("", item.Description);
                }
            }
            return View("AdminRegistration", reg);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
       
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Admin");
        }
    }
}
