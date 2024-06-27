using System.ComponentModel.DataAnnotations;

namespace BookingTourAPI.Common.ResponseModel
{
    public class GetUserRepsonse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // Additional user-specific properties
        public string Fullname { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
