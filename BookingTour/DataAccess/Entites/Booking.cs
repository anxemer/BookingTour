using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Booking
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
