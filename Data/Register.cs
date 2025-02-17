using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Data
{
    public class Register
    {
        [Required]
        public string? Name { get; set; }
        [Required]  
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string Role { get; set; }


    }
}
