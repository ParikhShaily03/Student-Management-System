
////using Microsoft.AspNetCore.Identity.Data;
////using Student_Management_System.Data;

//using System.Threading.Tasks;
//using System.Linq;
//using Microsoft.AspNetCore.Identity;
//using Student_Management_System.Models;
//using Microsoft.AspNetCore.Identity.Data;

//namespace Student_Management_System.Services
//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;

//        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        public async Task<string> Login(LoginRequest request)
//        {
//            // Find the user by email
//            var user = await _userManager.FindByEmailAsync(request.Email);
//            if (user == null)
//            {
//                return "Invalid login attempt";
//            }

//            // Attempt to sign in
//            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password,false, lockoutOnFailure: false);

//            if (!result.Succeeded)
//            {
//                return "Invalid login attempt";
//            }

//            return "User logged in successfully";
//        }

//        public Task<string> Loginrequest(Microsoft.AspNetCore.Identity.Data.LoginRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<string> RegisterRequest(Microsoft.AspNetCore.Identity.Data.RegisterRequest request)
//        {
//            // Registration logic here (same as before)
//          var user = new User
//            {
//                UserName = request.Email,
//                Email = request.Email,
//              Name = request.Email,
//              Role = request.ToString(),
//          };

//            var result = await _userManager.CreateAsync(user, request.Password);
//            if (!result.Succeeded)
//            {
//                return "Registration failed: " + string.Join(", ", result.Errors);
//            }

//            //if (!string.IsNullOrEmpty(request.Role))
//            //{
//            //    await _userManager.AddToRoleAsync(user, request.Role);
//            //}

//            return "User registered successfully";
//        }

//        public Task<string> Register(Models.RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object?> Register(Microsoft.AspNetCore.Identity.Data.RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Student_Management_System.Models;
using Student_Management_System.Data;

namespace Student_Management_System.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<string> Login(Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginRequest request)
        {
            // Log the login attempt using Serilog
            Log.Information("Login attempt for email {Email}", request.Email);

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                Log.Warning("Login failed: User with email {Email} not found.", request.Email);
                return "Invalid login attempt";
            }

            // Attempt to sign in using the user's username and password
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                Log.Warning("Login failed for user {Email}. Incorrect password.", request.Email);
                return "Invalid login attempt";
            }

            Log.Information("User {Email} logged in successfully.", request.Email);
            return "User logged in successfully";
        }

        public async Task<string> Register(RegisterRequest request)
        {
            // Log the registration attempt using Serilog
            Log.Information("Registration attempt for email {Email}", request.Email);

            // Create a new user based on the registration request
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                Role = request.Role
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                Log.Error("Registration failed for email {Email}. Errors: {Errors}", request.Email, errors);
                return "Registration failed: " + errors;
            }

            Log.Information("User {Email} registered successfully.", request.Email);
            return "User registered successfully";
        }

        public Task<object?> Register(Microsoft.AspNetCore.Identity.Data.RegisterRequest request)
        {
            throw new NotImplementedException();
        }





    }
}

