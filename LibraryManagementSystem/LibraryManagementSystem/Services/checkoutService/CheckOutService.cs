using LibraryManagementSystem.Repositories.CheckoutRepositry;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services.checkoutService
{
    public class CheckOutService : ICheckOutService
    {
        private readonly ICheckoutRepositry _checkoutRepositry;
        public CheckOutService(ICheckoutRepositry checkoutRepositry)
        {
            _checkoutRepositry = checkoutRepositry;
        }
        public IEnumerable<Checkout> GetAllCheckouts()
        {
            return _checkoutRepositry.GetAllCheckouts();
        }
        public RecoredCheckoutModelView GetMemberBooksData()
        {
            return _checkoutRepositry.GetMemberBooksData();
        }
        public void recordMemberBooks(string bookName, string memberUsername)
        {
            _checkoutRepositry.recordMemberBooks(bookName, memberUsername);
        }
        public void saveChanges()
        {
            _checkoutRepositry.saveChanges();
        }
    }
}
