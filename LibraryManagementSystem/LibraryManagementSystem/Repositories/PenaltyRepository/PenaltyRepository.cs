using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.PenaltyRepository
{
    public class PenaltyRepository : IPenaltyRepository
    {
        private readonly Library_Management_SystemContext _context;
        public PenaltyRepository(Library_Management_SystemContext context)
        {
            _context = context;
        }
        public IEnumerable<MemberPenaltyDetailsModelView> GetAllPenalties()
        {
            var penalties = _context.Penalties.Include(ch => ch.CheckOut).ThenInclude(ch => ch.Book)
                            .Include(ch => ch.CheckOut).ThenInclude(ch => ch.User);


            List<MemberPenaltyDetailsModelView> memberPenaltyDetails = new List<MemberPenaltyDetailsModelView>();
            foreach (var penalty in penalties)
            {
                MemberPenaltyDetailsModelView memberPenalty = new MemberPenaltyDetailsModelView()
                {
                    PenaltyId = penalty.PenaltyId,
                    CheckOutId = penalty.CheckOutId,
                    PaidStatus = penalty.PaidStatus ?? true,
                    PenaltyAmount = penalty.PenaltyAmount,

                    BookTitle = penalty.CheckOut.Book.Title,
                    CheckOutDate = penalty.CheckOut.CheckOutDate,
                    DueDate = penalty.CheckOut.DueDate,
                    MemberName = penalty.CheckOut.User.UserName,
                    ReturnDate = _context.Returns.FirstOrDefault(r => r.CheckOutId == penalty.CheckOut.CheckOutId).ReturnDate

                };
                memberPenaltyDetails.Add(memberPenalty);
            }
            return memberPenaltyDetails;
        }

        public void payPenalty(int PenaltyId)
        {
            var Specificpenalty = _context.Penalties.FirstOrDefault(p => p.PenaltyId == PenaltyId);
            Specificpenalty.PaidStatus = true;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
