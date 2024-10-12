using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services.checkoutService
{
    public interface ICheckOutService
    {
        public void recordMemberBooks(string bookName, string memberUsername);
        public IEnumerable<Checkout> GetAllCheckouts();
        public RecoredCheckoutModelView GetMemberBooksData();
        public void saveChanges();
    }
}
