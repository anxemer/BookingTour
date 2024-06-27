namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateTourRequest
    {
        public int HotelId { get; set; }
        public int ModifyBy { get; set; }
        public int CategoryTourId { get; set; }
        public DateTime StartDay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TotalDay { get; set; }
        public string Status { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
