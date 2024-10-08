using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.PenaltyRepository
{
    public interface IPenaltyRepository
    {
        public void payPenalty(int PenaltyId);
        public IEnumerable<MemberPenaltyDetailsModelView> GetAllPenalties();
        public void save();
        
    }
}
