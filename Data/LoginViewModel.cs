using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
