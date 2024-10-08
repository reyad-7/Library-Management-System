using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly Library_Management_SystemContext _context;
        public BookRepository(Library_Management_SystemContext context) { 
            _context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            var books = _context.Books.ToList();
            return books;

        }

        public IEnumerable<Book> Search(string title, string author, string genre)
        {
            var books = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                books = books.Where(b => b.Title == title);
            }
            if (!string.IsNullOrWhiteSpace(author))
            {
                books = books.Where(b => b.Author == author);
            }
            if (!string.IsNullOrWhiteSpace(genre))
            {
                books = books.Where(b => b.Genre == genre);
            }
            return books.ToList();
        }
    }
}
