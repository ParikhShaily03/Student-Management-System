using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Student_Management_System.Models
{
    public class User : IdentityUser
    {

        public string UserName { get; set; }
        public  string Role { get; set; }
    }
}