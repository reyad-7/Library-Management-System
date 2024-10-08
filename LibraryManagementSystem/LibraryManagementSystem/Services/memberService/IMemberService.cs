using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryManagementSystem.Services.memberService
{
    public interface IMemberService
    {
        public AppUser viewProfile(string userId);
        public void editProfile();
        public IEnumerable<Checkout> viewBorrowingHistory(string userId);
        public IEnumerable<MemberPortalViewModel> viewMemberProtal(string userId);
    }
}
