using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.RegistrationRepository
{
    public class RegistrationRepository : Controller,IRegistrationRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public RegistrationRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        } 
        public async Task<IActionResult> saveRegistration(RegistrationModelView reg, string RoleName, string ViewName)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Address = reg.Address;
                appUser.UserName = reg.UserName;
                appUser.PasswordHash = reg.Password;
                appUser.FullName = reg.FullName;
                appUser.Email = reg.Email;
                appUser.PhoneNumber = reg.PhoneNumber;

                IdentityResult result = await userManager.CreateAsync(appUser, reg.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, RoleName);
                    await signInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)

                        ModelState.AddModelError("", item.Description);
                }
            }
            return View(ViewName, reg);
        }
    }
}
