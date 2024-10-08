using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Repositories.ReturnRepository
{
    public interface IReturnRepository
    {
        public void recordReturn(int checkoutId);
        public IEnumerable<Return> getAllReturns();
        public void Save();

    }
}
