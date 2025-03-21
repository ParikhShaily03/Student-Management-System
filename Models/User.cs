using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Student_Management_System.Model
{
    public class User : IdentityUser
    {

        [Required]

        public string Name { get; set; }


        public string? Department { get; set; }

        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        }
    }

