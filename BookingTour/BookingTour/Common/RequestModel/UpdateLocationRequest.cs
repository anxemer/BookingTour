namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateLocationRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
