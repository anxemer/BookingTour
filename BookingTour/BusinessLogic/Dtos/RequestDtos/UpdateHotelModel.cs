using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateHotelModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ModifyBy { get; set; }
        public string Description { get; set; }
        public int TotalRoom { get; set; }
        public IFormFile File { get; set; }
    }
}
