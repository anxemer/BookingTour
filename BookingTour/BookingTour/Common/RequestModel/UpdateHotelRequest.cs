namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateHotelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ModifyBy { get; set; }
        public string Description { get; set; }
        public int TotalRoom { get; set; }
    }
}
