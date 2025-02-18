using Microsoft.AspNetCore.Identity.Data;
using Auth0.AuthenticationApi;


namespace Student_Management_System.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);

    }
}
