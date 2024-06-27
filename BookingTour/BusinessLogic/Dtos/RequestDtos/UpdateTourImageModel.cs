using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourImageModel
    {
        public int ImageId { get; set; }
        public IFormFile Url { get; set; }

    }
}
