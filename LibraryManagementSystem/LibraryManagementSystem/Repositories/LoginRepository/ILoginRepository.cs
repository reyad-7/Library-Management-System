using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.LoginRepository
{
    public interface ILoginRepository
    {
        public  Task<IActionResult> SaveLogin(UserLoginViewModel userLoginViewModel);
        public Task<IActionResult> SignOut(string ControllerName);


    }
}
