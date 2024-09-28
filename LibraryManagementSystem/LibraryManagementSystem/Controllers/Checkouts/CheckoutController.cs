using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Controllers.Checkouts
{
    public class CheckoutController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Library_Management_SystemContext _context;
        public CheckoutController(Library_Management_SystemContext context , IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public IActionResult recordMemberBooks(string bookName,int memberID)
        {
            DateTime dueDate = DateTime.Now;
            double x; 
            if (double.TryParse(_configuration["AppConstants:DueDate"], out x))
            {
                dueDate = dueDate.AddDays(x);
            }
            var book=_context.Books.FirstOrDefault(b=> b.Title == bookName);

            _context.Add(
                new Checkout()
                {
                    MemberId = memberID,
                    CheckOutDate = DateOnly.FromDateTime(DateTime.Now),
                    DueDate = DateOnly.FromDateTime(dueDate),
                    BookId = book.BookId,
                    Returned = false,
                }
             );
            _context.SaveChanges();
            return RedirectToAction("GetAllCheckouts");
        }
        public IActionResult GetAllCheckouts()
        {
            var checkouts = _context.Checkouts.Include(c => c.Member).Include(c => c.Book).ToList();
            return View(checkouts);
        }
        public IActionResult GetMemberBooksData() {
            var Titles = _context.Books.Where(b => b.NoOfCopies>0).Select(b => b.Title).ToList();
            var MembersIds =_context.Members.Select(m => m.MemberId).ToList();
            RecoredCheckoutModelView recoredCheckoutModelView = new RecoredCheckoutModelView() {
                BookTitles= Titles,
                MemberIDs=MembersIds
            };
            return View("recordMemberBooks", recoredCheckoutModelView);
        }
    }
}
