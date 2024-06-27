using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateTourImageModel
    {
        public int TourId { get; set; }

        public int AdminId { get; set; }

        public string Url { get; set; }
    }
}
