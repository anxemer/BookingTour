namespace BookingTourAPI.Common.ResponseModel
{
    public class GetHotelImageResponse
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int AdminId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
