using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Login
    {
      
        [EmailAddress]
        public required string Email { get; set; }

       
        public required string Name { get; set; }
       
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required bool RememberMe { get; set; } = false;
        
        public required string Role { get; set; }
    }
}
