using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class RevokedToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime RevokedAt { get; set; } = DateTime.UtcNow;
    }
}
