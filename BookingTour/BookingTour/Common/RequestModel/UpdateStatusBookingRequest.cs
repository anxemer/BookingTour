namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateStatusBookingRequest
    {
        public int Id { get; set; }

        public bool Status { get; set; }
    }
}
