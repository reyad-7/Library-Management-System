using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.ReturnRepository
{
    public class ReturnRepository : IReturnRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Library_Management_SystemContext _context;
        public ReturnRepository(Library_Management_SystemContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public IEnumerable<Return> getAllReturns()
        {
            return _context.Returns.ToList();

        }
        public void recordReturn(int checkoutId)
        {
            Return returnedBook = new Return()
            {
                CheckOutId = checkoutId,
                ReturnDate = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.Add(returnedBook);

            var checkOutBook = _context.Checkouts.FirstOrDefault(c => c.CheckOutId == checkoutId);
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
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
