using System.Security.Claims;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.memberService;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers.Members
{
    [Authorize(Roles = "User,Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService) { 
            _memberService = memberService;
        }
        public IActionResult viewProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profileData = _memberService.viewProfile(userId);

            return View(profileData);
        }
        public IActionResult editProfile()
        {
            return View();
        }
        public IActionResult viewBorrowingHistory() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var borrowedBooks = _memberService.viewBorrowingHistory(userId);
            return View(borrowedBooks);
        }
        public IActionResult viewMemberProtal() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_memberService.viewMemberProtal(userId));
        }
    }
}
