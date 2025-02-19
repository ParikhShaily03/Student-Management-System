using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Data
{
    public class Register
    {
        [Required]
        public string? Name { get; set; }
        [Required]  
        public string? Email { get; set; }
       
        public required string Password { get; set; }
        
        public required string Role { get; set; }


    }
}
