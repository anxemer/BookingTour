using System.ComponentModel.DataAnnotations;

namespace BookingTourAPI.Common.RequestModel
{
    public class CreateUserReques
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
        public string Fullname { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
