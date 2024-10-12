using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.LoginService;
using LibraryManagementSystem.Services.RegistrationService;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;

namespace LibraryManagementSystem.Controllers.UserAccount
{
    public class AccountController : Controller
    {
        private readonly IRegistrationService registeredServices;
        private readonly ILoginService loginService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , IRegistrationService registeredServices ,ILoginService loginService)
        {
            this.registeredServices = registeredServices;
            this.loginService = loginService;
        }
        
        [HttpGet]
        public IActionResult viewRegistrationForm()
        {
            return View("viewRegistrationForm");
        }
        [HttpPost]
        public async Task<IActionResult> saveRegistration(RegistrationModelView reg)
        {
            return await registeredServices.saveRegistration(reg ,"User", "viewRegistrationForm");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveLogin(UserLoginViewModel userLoginViewModel)
        {
            return await loginService.SaveLogin(userLoginViewModel);
        }
        public async Task<IActionResult> SignOut()
        {
            return await loginService.SignOut("Account");
        }

    }
}
