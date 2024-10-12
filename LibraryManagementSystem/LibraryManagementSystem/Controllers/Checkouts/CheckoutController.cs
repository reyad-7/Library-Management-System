using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.checkoutService;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Controllers.Checkouts
{
    [Authorize(Roles = "Admin")]
    public class CheckoutController : Controller
    {
        private readonly ICheckOutService _checkoutService;
        public CheckoutController(ICheckOutService checkOutService)
        {
            _checkoutService = checkOutService;
        }
        public IActionResult recordMemberBooks(string bookName, string memberUsername)
        {
            if (bookName == null || memberUsername == null)
            {
                return GetMemberBooksData() ;
            }
            _checkoutService.recordMemberBooks(bookName, memberUsername);
            _checkoutService.saveChanges();
            return RedirectToAction("GetAllCheckouts");
        }
        public IActionResult GetAllCheckouts()
        {
            var checkouts = _checkoutService.GetAllCheckouts(); 
            return View(checkouts);
        }
		public IActionResult GetMemberBooksData()
        {
            return View("recordMemberBooks", _checkoutService.GetMemberBooksData());
        }
    }
}
