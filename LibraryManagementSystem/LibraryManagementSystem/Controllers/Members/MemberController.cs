using System.Security.Claims;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers.Members
{
    [Authorize(Roles = "User")]
    public class MemberController : Controller
    {
        private readonly Library_Management_SystemContext _context;
        public MemberController(Library_Management_SystemContext context)
        {
            _context = context;
        }

        public IActionResult viewProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profileData = _context.AppUsers.FirstOrDefault(m => m.Id == userId );

            return View(profileData);
        }
        public IActionResult editProfile()
        {
            return View();
        }
        public IActionResult viewBorrowingHistory() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var borrowedBooks = _context.Checkouts.Include(c => c.Book).Where(c=>c.UserId==userId).ToList();
            return View(borrowedBooks);
        }
        public IActionResult viewMemberProtal() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var data = _context.Checkouts.Where(c => c.UserId==userId).Include(c => c.Book);


            List<MemberPortalViewModel> memberPenaltyDetails = new List<MemberPortalViewModel>();
            foreach (var item in data)
            {
                var pen = _context.Penalties.FirstOrDefault(p => p.CheckOutId == item.CheckOutId) ;
                MemberPortalViewModel MemberProtal = new MemberPortalViewModel();
                if (pen == null)
                {
                    MemberProtal.PaidStatus = true;
                    MemberProtal.PenaltyAmount = 0;
                } else {
                    MemberProtal.PenaltyAmount = pen.PenaltyAmount;
                    MemberProtal.PaidStatus = pen.PaidStatus ?? true;
                }
                MemberProtal.BookTitle = item.Book.Title;
                MemberProtal.CheckOutDate = item.CheckOutDate;
                MemberProtal.DueDate = item.DueDate;
                var ret = _context.Returns.FirstOrDefault(r => r.CheckOutId == item.CheckOutId);
                if (ret==null)
                {   
                    MemberProtal.ReturnDate = new DateOnly();
                }
                else
                {
                    MemberProtal.ReturnDate = ret.ReturnDate;
                }
                memberPenaltyDetails.Add(MemberProtal);
            }

            return View(memberPenaltyDetails);
        }
    }
}
