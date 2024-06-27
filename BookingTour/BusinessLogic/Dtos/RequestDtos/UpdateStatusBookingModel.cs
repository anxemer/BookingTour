using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateStatusBookingModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }

    }
}
