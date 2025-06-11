using Student_Management_System.Enums;

namespace Student_Management_System.Models.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> RoleIds { get; set; }
        public string? ImpersonatedBy { get; set; }
        public Dictionary<int, List<string>> MenuPermissions { get; set; }
        public string RefreshToken { get; set; } // Add this

        //public string UserId { get; set; }
        //public string Role { get; set; }
    }
}
