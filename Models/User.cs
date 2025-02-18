using Microsoft.AspNetCore.Identity;

namespace Student_Management_System.Models
{
    public class User :IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
