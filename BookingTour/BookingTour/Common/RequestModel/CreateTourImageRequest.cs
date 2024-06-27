namespace BookingTourAPI.Common.RequestModel
{
    public class CreateTourImageRequest
    {
        public int TourId { get; set; }

        public int AdminId { get; set; }

        public string Url { get; set; }
    }
}
