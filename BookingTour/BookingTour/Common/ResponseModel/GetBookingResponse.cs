namespace BookingTourAPI.Common.ResponseModel
{
    public class GetBookingResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
