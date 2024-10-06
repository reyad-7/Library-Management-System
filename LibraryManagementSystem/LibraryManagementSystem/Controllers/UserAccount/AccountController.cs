using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace LibraryManagementSystem.Controllers.UserAccount
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult viewRegistrationForm()
        {
            return View("viewRegistrationForm");
        }
        [HttpPost]
        public async Task<IActionResult> saveRegistration(RegistrationModelView reg)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Address = reg.Address;
                appUser.UserName = reg.UserName;
                appUser.PasswordHash = reg.Password;
                appUser.FullName = reg.FullName;

                IdentityResult result = await userManager.CreateAsync(appUser, reg.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "User");
                    await signInManager.SignInAsync(appUser, false);
                    /* 
                      Connect ASPUser with member model one to one relation
                        //Member member = new Member();
                        //member.FullName=;
                     
                     */

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)

                        ModelState.AddModelError("", item.Description);
                }
            }
            return View("viewRegistrationForm", reg);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[AllowAnonymous]
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
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
