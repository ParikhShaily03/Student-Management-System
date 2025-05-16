namespace Student_Management_System.Models.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        //  public  List <Menu> Menus { get; set; }


        //public string UserId { get; set; }
        //public string Role { get; set; }
    }
}
