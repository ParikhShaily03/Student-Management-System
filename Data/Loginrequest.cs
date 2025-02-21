
using System.ComponentModel.DataAnnotations;
using Student_Management_System.Data;
//using Student_Management_System.Models;

namespace Student_Management_System.Data
{
    public class LoginRequest
    {
        
        [EmailAddress]
        public string Email { get; set; }

       
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
