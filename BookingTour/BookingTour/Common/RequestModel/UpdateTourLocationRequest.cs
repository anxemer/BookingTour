namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateTourLocationRequest
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public int LocationId { get; set; }
    }
}
