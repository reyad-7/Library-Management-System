using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.CheckoutRepositry
{
    public class CheckoutRepositry : ICheckoutRepositry
    {
        private readonly IConfiguration _configuration;
        private readonly Library_Management_SystemContext _context;
        public CheckoutRepositry(Library_Management_SystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IEnumerable<Checkout> GetAllCheckouts()
        {
            return _context.Checkouts.Include(ch=>ch.User).Include(ch=>ch.Book).ToList();
        }

        public RecoredCheckoutModelView GetMemberBooksData()
        {
            var Titles = _context.Books.Where(b => b.NoOfCopies > 0).Select(b => b.Title).ToList();
            var nonAdminUsers = from u in _context.AppUsers
                                join userRole in _context.UserRoles on u.Id equals userRole.UserId
                                join role in _context.Roles on userRole.RoleId equals role.Id
                                where role.Name != "Admin"
                                select u;

            var MembersUsername = nonAdminUsers.Select(m => m.UserName).ToList();
            RecoredCheckoutModelView recoredCheckoutModelView = new RecoredCheckoutModelView()
            {
                BookTitles = Titles,
                MembersUsername = MembersUsername
            };
            return recoredCheckoutModelView;
        }

        public void recordMemberBooks(string bookName, string memberUsername)
        {
            DateTime dueDate = DateTime.Now;
            double x;
            if (double.TryParse(_configuration["AppConstants:DueDate"], out x))
            {
                dueDate = dueDate.AddDays(x);
            }
            var book = _context.Books.FirstOrDefault(b => b.Title == bookName);

            book.NoOfCopies--;
            _context.Checkouts.Add(
                new Checkout()
                {
                    UserId = _context.AppUsers.FirstOrDefault(u => u.UserName == memberUsername).Id,
                    CheckOutDate = DateOnly.FromDateTime(DateTime.Now),
                    DueDate = DateOnly.FromDateTime(dueDate),
                    BookId = book.BookId,
                    Returned = false,
                }
             );
        }
        public void saveChanges()
        {
            _context.SaveChanges();
        }

    }
}
