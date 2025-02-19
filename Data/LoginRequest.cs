﻿using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Data
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
