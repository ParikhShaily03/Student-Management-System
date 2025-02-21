using System.ComponentModel.DataAnnotations;
namespace Student_Management_System.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
