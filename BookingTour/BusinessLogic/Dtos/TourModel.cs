using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class TourModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
        public int CategoryTourId { get; set; }
        public DateTime StartDay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TotalDay { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
