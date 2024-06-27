using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateUserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
