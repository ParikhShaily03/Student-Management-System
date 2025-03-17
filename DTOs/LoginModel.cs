using System.ComponentModel.DataAnnotations;
namespace Student_Management_System.Models
{
    public class LoginModel
    {
        [Required]

        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
