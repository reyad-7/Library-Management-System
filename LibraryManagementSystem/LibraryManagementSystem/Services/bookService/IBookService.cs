using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Services.bookService
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public IEnumerable<Book> searchBook(string title, string author, string genre);
        
    }
}
