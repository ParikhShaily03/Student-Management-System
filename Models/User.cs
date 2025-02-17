using Microsoft.AspNetCore.Identity;

namespace Student_Management_System.Models
{
    public class User :IdentityUser
    {
        public string Role { get; set; }
    }
}
