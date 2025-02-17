using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Auth0.AuthenticationApi;
using Microsoft.AspNetCore.Identity.Data;


namespace Student_Management_System.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);

    }
}
