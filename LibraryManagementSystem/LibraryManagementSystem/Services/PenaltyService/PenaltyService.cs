using LibraryManagementSystem.Repositories.PenaltyRepository;
using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.Services.PenaltyService
{
    public class PenaltyService : IPenaltyService
    {
        private readonly IPenaltyRepository _penaltyRepositry ;
        public PenaltyService(IPenaltyRepository penaltyRepository) {
            _penaltyRepositry = penaltyRepository;
        }
        public IEnumerable<MemberPenaltyDetailsModelView> GetAllPenalties()
        {
            return _penaltyRepositry.GetAllPenalties() ;
        }

        public void payPenalty(int PenaltyId)
        {
            _penaltyRepositry.payPenalty(PenaltyId) ;
        }

        public void save()
        {
            _penaltyRepositry.save() ;
        }
    }
}
