﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourLocationModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }

        public int LocationId { get; set; }
    }
}
