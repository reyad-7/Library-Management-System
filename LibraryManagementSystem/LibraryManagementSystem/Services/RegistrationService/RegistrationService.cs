using LibraryManagementSystem.Repositories.RegistrationRepository;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository) {
            this.registrationRepository = registrationRepository;
        }
        public Task<IActionResult> saveRegistration(RegistrationModelView reg, string RoleName, string ViewName)
        {
            return registrationRepository.saveRegistration(reg, RoleName,ViewName);
        }
    }
}
