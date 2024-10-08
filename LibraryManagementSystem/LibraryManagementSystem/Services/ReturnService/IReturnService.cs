using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.ReturnService
{
    public interface IReturnService
    {
        public void recordReturn(int checkoutId);
        public IEnumerable<Return> getAllReturns();
        public void Save();
    }
}
