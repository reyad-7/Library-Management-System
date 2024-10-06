using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{
    public class AppUser:IdentityUser
    {
        public string? Address { get; set; }

        public string? FullName { get; set; }

        public virtual List<Checkout> Checkouts { get; set; } = new List<Checkout>();
    }
}
