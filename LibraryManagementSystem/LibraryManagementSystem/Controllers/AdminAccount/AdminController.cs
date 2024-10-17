using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.LoginService;
using LibraryManagementSystem.Services.RegistrationService;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.AdminAccount
{
    public class AdminController : Controller
    { 
        private readonly IRegistrationService registrationService;
        private readonly ILoginService loginService;

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IRegistrationService registrationService,ILoginService loginService)
        {
            this.registrationService = registrationService;
            this.loginService = loginService;
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
            return await registrationService.saveRegistration(reg, "Admin", "AdminRegistration");
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
            return await loginService.SignOut("Admin");
        }
    }
}
