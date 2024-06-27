namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateTiketRequset
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime BookingDate { get; set; }
        public double TotalBill { get; set; }
    }
}
