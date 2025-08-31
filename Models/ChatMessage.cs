// Models/ChatMessage.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }
    }

    public class SendMessageDto
    {
        public string ToUserId { get; set; }
        public string Message { get; set; }
    }

}
