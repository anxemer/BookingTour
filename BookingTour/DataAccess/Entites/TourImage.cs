using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class TourImage
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }

        
        public string? Url { get; set; }
        

    }
}
