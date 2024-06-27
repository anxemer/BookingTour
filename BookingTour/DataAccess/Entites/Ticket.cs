using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("Ticket")]
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        public int? ModifyBy { get; set; }
        public int AmoutPeople { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public double TotalBill { get; set; }
    }
}
