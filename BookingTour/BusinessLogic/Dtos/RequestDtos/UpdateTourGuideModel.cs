using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourGuideModel
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
