﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateLocationModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
