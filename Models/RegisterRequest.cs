using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.Data;

namespace Student_Management_System.Models
{
    public class RegisterRequest
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }
    }
}
