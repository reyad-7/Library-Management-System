using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.MemberRepository
{
    public interface IMemberRepository
    {
        public AppUser viewProfile(string userId);
        public void editProfile();
        public IEnumerable<Checkout> viewBorrowingHistory(string userId);
        public IEnumerable<MemberPortalViewModel> viewMemberProtal(string userId);
    }
}
