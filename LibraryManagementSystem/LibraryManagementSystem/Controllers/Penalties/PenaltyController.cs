using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.PenaltyService;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers.Penalties
{
    [Authorize(Roles = "Admin")]
    public class PenaltyController : Controller
    {
        private readonly IPenaltyService _penaltyService;

        public PenaltyController(IPenaltyService penaltyService)
        {
            _penaltyService = penaltyService;
        }

        public IActionResult payPenalty(int PenaltyId)
        {
            _penaltyService.payPenalty(PenaltyId);
            _penaltyService.save();
            return RedirectToAction("GetAllPenalties");
        }
        public IActionResult GetAllPenalties()
        {
            var penalties = _penaltyService.GetAllPenalties(); 
            return View(penalties);
        }
    }
}
