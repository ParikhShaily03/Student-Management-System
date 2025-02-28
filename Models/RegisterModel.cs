using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }  // Admin, User
    }
}
