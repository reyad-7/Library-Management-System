using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.MemberRepository;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.memberService
{
    
    public class memberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public memberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void editProfile()
        {
            return;
        }

        public IEnumerable<Checkout> viewBorrowingHistory(string userId)
        {
            return _memberRepository.viewBorrowingHistory(userId);
        }

        public IEnumerable<MemberPortalViewModel> viewMemberProtal(string userId)
        {
            return _memberRepository.viewMemberProtal(userId);
        }

        public AppUser viewProfile(string userId)
        {
            return _memberRepository.viewProfile(userId);
        }
    }
}
