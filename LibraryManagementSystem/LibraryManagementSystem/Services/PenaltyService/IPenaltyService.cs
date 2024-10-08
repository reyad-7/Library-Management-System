using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.Services.PenaltyService
{
    public interface IPenaltyService
    {
        public void payPenalty(int PenaltyId);
        public IEnumerable<MemberPenaltyDetailsModelView> GetAllPenalties();
        public void save();
    }
}
