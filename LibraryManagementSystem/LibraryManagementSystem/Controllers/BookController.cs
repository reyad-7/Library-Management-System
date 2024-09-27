using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly Library_Management_SystemContext _context;

        public BookController(Library_Management_SystemContext context)
        {
            _context = context;
        }

        public IActionResult GetAllBooks()
        {
            var books = _context.Books.ToList();
            return View(books);
        }


        [HttpGet]
        public IActionResult searchBook(string title, string author, string genre)
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
            return View(books.ToList());
        }
    }
}