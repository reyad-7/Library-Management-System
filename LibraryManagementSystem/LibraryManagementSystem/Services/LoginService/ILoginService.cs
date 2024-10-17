using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.LoginService
{
    public interface ILoginService
    {
        public Task<IActionResult> SaveLogin(UserLoginViewModel userLoginViewModel);
        public Task<IActionResult> SignOut(string ControllerName);

    }
}
