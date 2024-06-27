﻿namespace BookingTourAPI.Common.RequestModel
{
    public class CreateTicketRequest
    {
        public int TourId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public int AmoutPeople { get; set; }

        public double TotalBill { get; set; }
    }
}