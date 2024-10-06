using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers.Returns
{
    [Authorize(Roles = "Admin")]
    public class ReturnController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Library_Management_SystemContext _context;
        public ReturnController(Library_Management_SystemContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult recordReturn(int checkoutId)
        {
            
            Return returnedBook = new Return()
            {
                CheckOutId = checkoutId,
                ReturnDate = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.Add(returnedBook);

            var checkOutBook  = _context.Checkouts.FirstOrDefault(c=> c.CheckOutId == checkoutId);
            checkOutBook.Returned = true;


            DateTime returnedDateTime = returnedBook.ReturnDate.ToDateTime(new TimeOnly(0, 0));
            DateTime dueDateTime = checkOutBook.DueDate.ToDateTime(new TimeOnly(0, 0));
            
            int daysDifference = (returnedDateTime - dueDateTime).Days;

            decimal penaltyCost = decimal.Parse(_configuration["AppConstants:Penalty"]);

            if (daysDifference > 0)
            {
                Penalty penalty = new Penalty()
                {
                    CheckOutId = checkoutId,
                    PenaltyAmount = daysDifference * penaltyCost,
                    PaidStatus = false,
                };
                _context.Add(penalty);
            }
            _context.SaveChanges();
            return RedirectToAction("getAllReturns");
        }

        

        public IActionResult getAllReturns()
        {
            var returns = _context.Returns.ToList();

            return View(returns);
        }

    }
}
