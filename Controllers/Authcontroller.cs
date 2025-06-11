using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;
using Student_Management_System.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


//using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {


        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);

            if (result == "A user with this email already exists.")
                return BadRequest(new { message = result });

            if (result.Contains("A user with this username already exists."))
                return BadRequest(new { message = result });

            if (result == ApiMessage.RegistrationFailed)
                return StatusCode(500, new { message = result });

            return Ok(new { message = result });

            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _authService.LoginAsync(model);
            if (response == null)
                return Unauthorized(ApiMessage.LoginFailed);

            return Ok(new { message = ApiMessage.LoginSuccess, data = response });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = await _authService.LogoutAsync(token);
            if (!result) return BadRequest("Invalid token");
            return Ok(new { message = "Logout successful" });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var response = await _authService.RefreshTokenAsync(request.Token, request.RefreshToken);
            if (response == null)
                return Unauthorized(ApiMessage.InvalidRefreshToken);

            return Ok(new { message = ApiMessage.TokenRefreshed, data = response });
        }



        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var success = await _authService.SendPasswordResetOtpAsync(dto.Email);
            if (!success)
                return BadRequest("Email not found.");

            return Ok(new { message = "OTP sent successfully." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var success = await _authService.ResetPasswordWithOtpAsync(dto.Email, dto.Otp, dto.NewPassword);
            if (!success)
                return BadRequest("Invalid or expired OTP.");


            return Ok(new { message = "Password reset successful." });

           
        }

        [HttpPost("mimic")]
        public async Task<IActionResult> MimicUser([FromBody] MimicUserRequest request)
        {
            var currentUser = User.Identity?.Name;

            if (string.IsNullOrEmpty(currentUser))
            return Ok(new { message = "Current user not found." });

            // OPTIONAL: Check if current user is admin
            var isAdmin = User.IsInRole("Admin"); // Or use claims
            if (!isAdmin)
            return Ok(new { message = "Only admins can mimic users." });

            var response = await _authService.MimicUserAsync(request.TargetUserName, currentUser);
            if (response == null)
            return Ok(new { message = "Target user not found." });

            return Ok(new { message = "Mimic successful", data = response });
        }


    }
}




