namespace BookingTourAPI.Common.RequestModel
{
    public class CreateHotelRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int TotalRoom { get; set; }
        public List<IFormFile> Files { get; set; }

    }
}
