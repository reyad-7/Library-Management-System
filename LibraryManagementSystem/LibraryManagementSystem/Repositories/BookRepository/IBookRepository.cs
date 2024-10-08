using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.BookRepository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public IEnumerable<Book> Search(string title, string author, string genre);
    }
}
