using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateStatusTicketModel
    {
        public int Id { get; set; }
        public string PaymentStatus { get; set; }

    }
}
