using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateBookingModel
    {
        public int TourId { get; set; }
        public bool Status { get; set; }
    }
}
