//using Microsoft.IdentityModel.Tokens;
//using Microsoft.AspNetCore.Identity;
//using Student_Management_System.Models;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Diagnostics;
//using Student_Management_System.Migrations.Models;

//namespace Student_Management_System.Services

//{
//    public class AuthenticatioService : IAuthenticationService
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly IConfiguration _configuration;
//        public AuthenticatioService(UserManager<User> userManager, IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _configuration = configuration;
//        }

//        public async Task<string> Login(Login request)
//        {
//            var userByEmail = await _userManager.FindByNameAsync(request.Email);
//            var userByName = await _userManager.FindByNameAsync(request.Name);
//            if (userByEmail is not null || userByName is not null)
//            {
//                throw new ArgumentException($"User with email {request.Email} or username {request.Name} already exists.");
//            }

//            throw new NotImplementedException();
//            User user = new User()
//            {
//                Email = request.Email,
//                Name = request.Name,
//                SecurityStamp = Guid.NewGuid().ToString()
//            };
//            var result = await _userManager.CreateAsync(user, request.Password);

//            if (!result.Succeeded)
//            {
//                throw new ArgumentException($"Unable to register user {request.Name} errors:{GetErrorsText(result.Errors)}");
//            }

//           return await Login(new Login{ Email = request.Email, Password = request.Password });
//        }

//        public Task<string> Login(LoginRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<string> Register(RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<string> Register(Microsoft.AspNetCore.Identity.Data.RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<string> Register(Models.RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        private string GetErrorsText(IEnumerable<IdentityError> errors)
//        {
//            return string.Join(", ", errors.Select(error => error.Description).ToArray());
//        }
//    }
//}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Student_Management_System.Data;
using Student_Management_System.Data.DTO;
using Student_Management_System.Migrations.Models;
using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext? context;

        public AuthenticationService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;

        }

        public async Task<string> Register(RegisterRequest request)
        {
            // Check if the user already exists
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new ArgumentException($"User with email {request.Email} already exists.");
            }

            // Create the user
            var newUser = new User();
            newUser.UserName = request.UserName;
            newUser.Email = request.Email;
            newUser.SecurityStamp = Guid.NewGuid().ToString();

            // return await Login(new Login { Email = request.Email, Password = request.Password });
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException($"Registration failed: {GetErrorsText(result.Errors)}");
            }
            return await Login(new Login { Email = request.Email, Password = request.Password });


            //var result = await _userManager.CreateAsync(newUser, request.Password);
            //return new string("");

            // Check if user creation succeeded
            //if (!result.Succeeded)
            //{
            //    throw new ArgumentException($"Registration failed: {GetErrorsText(result.Errors)}");
            //}

            // Automatically log in the user after registration
            //return await Login(new Login { Email = request.Email, Password = request.Password });
        }

       // public async Task<string> Login(Login request)
            public async Task<string> Login(LoginRequest request)

        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, request.Password)))
            {
                throw new ArgumentException("Invalid email or password.");
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);
            return token;
        }

        private string GenerateJwtToken(User user)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // Ensure Role is included
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description));
        }

        public Task<string> Login(Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(object req)
        {
            throw new NotImplementedException();
        }
    }
}
