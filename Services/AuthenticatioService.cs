using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Student_Management_System.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

namespace Student_Management_System.Services

{
    public class AuthenticatioService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenticatioService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> Login(Login request)
        {
            var userByEmail = await _userManager.FindByNameAsync(request.Email);
            var userByName = await _userManager.FindByNameAsync(request.Name);
            if (userByEmail is not null || userByName is not null)
            {
                throw new ArgumentException($"User with email {request.Email} or username {request.Name} already exists.");
            }

            throw new NotImplementedException();
            User user = new()
            {
                Email = request.Email,
                Name = request.Name,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {request.Name} errors:{GetErrorsText(result.Errors)}");
            }

           return await Login(new Login{ Email = request.Email, Password = request.Password });
        }

        public Task<string> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description).ToArray());
        }
    }
}

