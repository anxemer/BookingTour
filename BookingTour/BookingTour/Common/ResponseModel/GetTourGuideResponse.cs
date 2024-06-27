namespace BookingTourAPI.Common.ResponseModel
{
    public class GetTourGuideResponse
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TicketId { get; set; }

    }
}
