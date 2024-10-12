using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.RegistrationRepository
{
    public interface IRegistrationRepository
    {
        public  Task<IActionResult> saveRegistration(RegistrationModelView reg, string RoleName,string ViewName);
        
    }
}
