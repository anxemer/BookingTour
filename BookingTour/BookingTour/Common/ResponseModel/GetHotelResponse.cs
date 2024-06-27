namespace BookingTourAPI.Common.ResponseModel
{
    public class GetHotelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AdminId { get; set; }
        public string Description { get; set; }
        public int TotalRoom { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
