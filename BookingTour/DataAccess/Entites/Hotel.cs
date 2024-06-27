﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CreateBy { get; set; }
        [ForeignKey("CreateBy")]
        public User Admin { get; set; }
        public string Status { get; set; }
        public int ModifyBy { get; set; }

        public string Description { get; set; }
        public int TotalRoom { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
