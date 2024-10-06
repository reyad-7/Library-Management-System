namespace LibraryManagementSystem.ViewModel
{
    public class MemberPortalViewModel
    {
        public decimal? PenaltyAmount { get; set; }
        public bool PaidStatus { get; set; }
        public string BookTitle { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}
