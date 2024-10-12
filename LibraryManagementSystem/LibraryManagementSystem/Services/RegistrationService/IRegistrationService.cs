using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.RegistrationService
{
    public interface IRegistrationService
    {
        public Task<IActionResult> saveRegistration(RegistrationModelView reg, string RoleName,string ViewName);
    }
}
