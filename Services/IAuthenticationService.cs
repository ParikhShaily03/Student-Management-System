using Microsoft.AspNetCore.Identity.Data;
using Auth0.AuthenticationApi;
using Student_Management_System.Models;
using System.Threading.Tasks;
using Student_Management_System.Data.DTO;

namespace Student_Management_System.Services
{
    public interface IAuthenticationService
    {
        //Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);
        Task<string> Login(HttpRequest request);
        Task<string> Login(object req);

        // Task<string> Login(Data.LoginRequest request);
        Task<string> Register(Data.DTO.RegisterRequest request);
    }
}
