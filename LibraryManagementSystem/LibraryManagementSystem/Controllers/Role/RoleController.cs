using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.Role
{
    [Authorize (Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task<ActionResult> AddRole(RoleModelView roleModelView)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleModelView.RoleName;
                IdentityResult res = await roleManager.CreateAsync(identityRole);
                if (res.Succeeded)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
