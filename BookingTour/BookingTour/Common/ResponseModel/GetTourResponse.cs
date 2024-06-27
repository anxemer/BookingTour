namespace BookingTourAPI.Common.ResponseModel
{
    public class GetTourResponse
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int AdminId { get; set; }
        public int CategoryTourId { get; set; }
        public DateOnly StartDay { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TotalDay { get; set; }
    }
}
