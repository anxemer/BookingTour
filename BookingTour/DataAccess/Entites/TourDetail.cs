using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class TourDetail
    {
        [Key,ForeignKey("TourId")]
        public int TourId { get; set; } // Khóa chính và khóa ngoại tới Tour
        public Tour Tour { get; set; } // Quan hệ một-một với Tour
        //Số người tối đa của tour
        public int TotalSlot { get; set; }
        //Số slot trống của tour
        public int AvailableSlot { get; set; }
        //Địa Điểm khởi hành
        public string DepartureLocation { get; set; }
        //Điểm đến
        public string DestinationLocation { get; set; }
        public string Description { get; set; }
        public string Transportation { get; set; }
        public double TotalPrice { get; set; }
        public double PricePerPerson { get; set; }

    }
}
