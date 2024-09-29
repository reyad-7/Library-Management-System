using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.ViewModel
{
    public class MemberPenaltyDetailsModelView
    {
        public int PenaltyId { get; set; }
        public int? CheckOutId { get; set; }
        public decimal? PenaltyAmount { get; set; }
        public bool PaidStatus { get; set; }
        public string MemberName { get; set; }
        public string BookTitle {  get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly ReturnDate { get; set; }


    }
}
