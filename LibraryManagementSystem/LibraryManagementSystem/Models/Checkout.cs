using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public partial class Checkout
{
    [Key]
    [Column("CheckOutID")]
    public int CheckOutId { get; set; }

    [Column("BookID")]
    public int? BookId { get; set; }

    [Column("CheckOut_Date")]
    public DateOnly CheckOutDate { get; set; }

    [Column("Due_Date")]
    public DateOnly DueDate { get; set; }

    public bool Returned { get; set; }

    [Column("userID")]
    [StringLength(450)]
    public string UserId { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Checkouts")]
    public virtual Book Book { get; set; }

    [ForeignKey("UserId")] // Establish the foreign key relationship with AppUser
    [InverseProperty("Checkouts")]
    public virtual AppUser User { get; set; } // Add this line to reference AppUser

    [InverseProperty("CheckOut")]
    public virtual ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();

    [InverseProperty("CheckOut")]
    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();
}
