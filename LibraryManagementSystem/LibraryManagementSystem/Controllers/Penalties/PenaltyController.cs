using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers.Penalties
{
    public class PenaltyController : Controller
    {
        private readonly Library_Management_SystemContext _context;

        public PenaltyController (Library_Management_SystemContext context)
        {
            _context = context;
        }

        public IActionResult payPenalty(int PenaltyId)
        {
            var Specificpenalty = _context.Penalties.FirstOrDefault(p => p.PenaltyId==PenaltyId);
            Specificpenalty.PaidStatus = true;

            _context.SaveChanges();
            return RedirectToAction("GetAllPenalties");
        }

        public IActionResult GetAllPenalties()
        {

            var penalties = _context.Penalties.Include(ch => ch.CheckOut).ThenInclude(ch => ch.Book)
                            .Include(ch => ch.CheckOut).ThenInclude(ch=>ch.Member);

            
            List<MemberPenaltyDetailsModelView> memberPenaltyDetails = new List<MemberPenaltyDetailsModelView>();
            foreach (var penalty in penalties)
            {
                MemberPenaltyDetailsModelView memberPenalty = new MemberPenaltyDetailsModelView()
                {
                    PenaltyId = penalty.PenaltyId,
                    CheckOutId = penalty.CheckOutId,
                    PaidStatus = penalty.PaidStatus,
                    PenaltyAmount = penalty.PenaltyAmount,

                    BookTitle = penalty.CheckOut.Book.Title,
                    CheckOutDate = penalty.CheckOut.CheckOutDate,
                    DueDate = penalty.CheckOut.DueDate,
                    MemberName = penalty.CheckOut.Member.FullName,
                    ReturnDate = _context.Returns.FirstOrDefault(r => r.CheckOutId == penalty.CheckOut.CheckOutId).ReturnDate

                };
                memberPenaltyDetails .Add(memberPenalty);
            }

            return View(memberPenaltyDetails);
        }
    }
}
