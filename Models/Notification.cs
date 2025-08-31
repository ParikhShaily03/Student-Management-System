using System;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }  // Target user
        public string Title { get; set; }
        public string Message { get; set; }

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
