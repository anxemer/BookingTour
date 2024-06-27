using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateHotelModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int TotalRoom { get; set; }
        public List<IFormFile> Files { get; set; }
        
    }
}
