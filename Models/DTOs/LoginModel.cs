using System.ComponentModel.DataAnnotations;
namespace Student_Management_System.Models.DTOs
{
    public class LoginModel
    {
        [Required]

        
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
   

}
public class RefreshTokenRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
