using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTourAPI.Common.AuthViewModel
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        
        public string Message { get; set; }
        
        public object Data { get; set; }
    }
}
