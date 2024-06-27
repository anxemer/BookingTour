namespace BookingTourAPI.Common.ResponseModel
{
    public class GetTourImageRepsonse
    {
        public int Id { get; set; }
        public int TourId { get; set; }

        public int AdminId { get; set; }

        public string Url { get; set; }
    }
}
