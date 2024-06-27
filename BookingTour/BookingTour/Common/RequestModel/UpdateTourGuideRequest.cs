namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateTourGuideRequest
    {
        public int TotalSlot { get; set; }
        public int AvailableSlot { get; set; }
        public string DepartureLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string Description { get; set; }
        public string Transportation { get; set; }
        public double TotalPrice { get; set; }
        public double PricePerPerson { get; set; }
    }
}
