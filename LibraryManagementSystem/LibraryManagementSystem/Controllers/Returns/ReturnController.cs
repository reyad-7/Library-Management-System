using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.ReturnService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.Returns
{
    [Authorize(Roles = "Admin")]
    public class ReturnController : Controller
    {
        private readonly IReturnService _returnService;

        public ReturnController (IReturnService returnService)
        {
            _returnService = returnService;
        }

        public IActionResult recordReturn(int checkoutId)
        {
            _returnService.recordReturn(checkoutId);
            _returnService.Save();
            return RedirectToAction("getAllReturns");
        }

        

        public IActionResult getAllReturns()
        {
            var returns = _returnService.getAllReturns();
            return View(returns);
        }

    }
}
