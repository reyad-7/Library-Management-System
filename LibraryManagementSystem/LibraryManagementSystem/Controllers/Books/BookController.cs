using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.bookService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagementSystem.Controllers.Books
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }


        [HttpGet]
        public IActionResult searchBook(string title, string author, string genre)
        {
            var Books = _bookService.searchBook(title, author, genre);
            return View(Books);
        }
    }
}