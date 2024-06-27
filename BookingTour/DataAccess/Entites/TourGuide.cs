using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class TourGuide
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public int ModifyBy { get; set; }
        public int CreateBy { get; set; }
        public int? TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; } // Quan hệ một-nhiều với Ticket
    }
}
