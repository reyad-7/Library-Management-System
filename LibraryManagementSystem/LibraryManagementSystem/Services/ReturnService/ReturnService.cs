using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.ReturnRepository;

namespace LibraryManagementSystem.Services.ReturnService
{

    public class ReturnService : IReturnService
    {
        private readonly IReturnRepository _returnRepository;
        public  ReturnService(IReturnRepository returnRepository) {
            _returnRepository = returnRepository;
        }
        public IEnumerable<Return> getAllReturns()
        {
           return _returnRepository.getAllReturns();
        }
        public void recordReturn(int checkoutId)
        {
             _returnRepository.recordReturn(checkoutId);
        }
        public void Save()
        {
            _returnRepository.Save();
        }
    }
}
