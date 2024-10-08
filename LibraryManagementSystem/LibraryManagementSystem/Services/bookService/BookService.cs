using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.BookRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services.bookService
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        

        IEnumerable<Book> IBookService.GetAllBooks()
        {
            return _bookRepository.GetAll();
            
        }
        IEnumerable<Book> IBookService.searchBook(string title, string author, string genre)
        {
            return _bookRepository.Search(title,author,genre);
        }
    }
}
