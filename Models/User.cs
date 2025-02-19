using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Student_Management_System.Models
{
    public class User :IdentityUser
    {
       
        public required string Name { get; set; }
        public required string Role { get; set; }
    }
}
