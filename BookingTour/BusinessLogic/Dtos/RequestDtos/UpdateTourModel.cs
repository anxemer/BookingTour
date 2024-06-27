using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourModel
    {
        public int HotelId { get; set; }
        public int ModifyBy { get; set; }
        public int CategoryTourId { get; set; }
        public DateTime StartDay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TotalDay { get; set; }
        public string Status { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
