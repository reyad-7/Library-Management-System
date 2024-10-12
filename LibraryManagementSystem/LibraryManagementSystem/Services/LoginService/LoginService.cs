using LibraryManagementSystem.Repositories.LoginRepository;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository) {
            this.loginRepository = loginRepository;
        }

        public Task<IActionResult> SaveLogin(UserLoginViewModel userLoginViewModel)
        {
            return loginRepository.SaveLogin(userLoginViewModel); 
        }
        public async Task<IActionResult> SignOut(string ControllerName)
        {
            return await loginRepository.SignOut(ControllerName);
        }
    }
}
