using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

    }
}






//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;
//        private readonly IConfiguration _configuration;
//        private readonly ApplicationDbContext _dbContext;
//        private readonly IRoleRepository _roleRepository;
//        private readonly IEmailService _emailService;


//        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ApplicationDbContext dbContext, IRoleRepository roleRepository, IEmailService emailService)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _configuration = configuration;
//            _dbContext = dbContext;
//            _roleRepository = roleRepository;
//            _emailService = emailService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//                return Ok(ApiMessage.BadRequest);

//            User usernew = new User
//            {
//                Email = model.Email,
//                UserName = model.UserName, // Ensuring UserName is set
//                Name = model.Name // Or model.Name if Name is provided in the DTO
//            };
//            var result = await _userManager.CreateAsync(usernew, model.Password);

//            if (!result.Succeeded)
//                return Ok(ApiMessage.RegistrationFailed);

//            var subject = "🎉 Welcome to Our App – Enjoy Your 14-Day Free Trial!";
//            var body = $@"
//            <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
//                        <h2 style='color: #4CAF50;'>Thank you for registering, {model.Name}!</h2>
//                        <p>We're excited to have you join us. 🎉</p>
//                        <p>You now have <strong>14 days of free access</strong> to explore everything our app has to offer.</p>

//                        <p>Here’s what you can do:</p>
//                        <ul>
//                            <li>Access premium features</li>
//                            <li>Manage your student data efficiently</li>
//                            <li>Get helpful support</li>
//                        </ul>

//                        <p>Need help? Just reply to this email — we’re here for you.</p>

//                        <p style='margin-top: 30px;'>Happy exploring!<br><strong>The Student Management System Team</strong></p>
//             </div>
//";

//            await _emailService.SendEmailAsync(model.Email, subject, body);


//            // await _userManager.AddToRoleAsync(usernew, model.Role);
//            return Ok(new { message = ApiMessage.RegistrationSuccess });
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginModel model)
//        {
//            var user = await _userManager.FindByNameAsync(model.UserName)
//         ?? await _userManager.FindByEmailAsync(model.UserName);
//            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
//                return Unauthorized(ApiMessage.LoginFailed);

//            // var roles = await _userManager.GetRolesAsync(user);
//            var roles = await _roleRepository.GetUserRolesAsync(user.Id);
//            var roleIds = roles.Select(r => r.Id).ToList();

//            var roleNames = roles.Select(r => r.Name).ToList();

//            var permissionIds = await _dbContext.RolePermissions
//                .Where(rp => roleNames.Contains(rp.Role.Name))
//                .Select(rp => rp.Permission.Name)
//                .Distinct()
//                .ToListAsync();

//            //var token = GenerateJwtToken(user, roles.FirstOrDefault() ?? "User");
//            var token = GenerateJwtToken(user, roleNames, roleIds, permissionIds);

//            return Ok(new
//            {
//                message = ApiMessage.LoginSuccess,
//                data = new AuthResponse
//                {

//                    Token = token,
//                    UserId = user.Id,
//                    Roles = roleNames.ToList(),
//                    RoleIds = roleIds.ToList(),
//                    Permissions = permissionIds.ToList(),

//                    //Menus = menus.ToList(),
//                }
//            });
//        }

//        [HttpPost("logout")]
//        public async Task<IActionResult> Logout()
//        {
//            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

//            if (string.IsNullOrEmpty(token))
//                return BadRequest("Invalid token");

//            // Save the token to the revoked tokens table
//            await _dbContext.RevokedTokens.AddAsync(new RevokedToken { Token = token });
//            await _dbContext.SaveChangesAsync();

//            return Ok(new { message = "Logout successful" });
//        }




//        private string  GenerateJwtToken(User user, IList<string> roles, IList<string> roleIds, IList<string> permissions)
//        {
//            var jwtSettings = _configuration.GetSection("JwtSettings");
//            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

//            var claims = new List<Claim>
//    {
//        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
//        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
//        new Claim(JwtRegisteredClaimNames.Email, user.Email)
//    };

//            // Add all roles dynamically
//            foreach (var role in roles)
//            {
//                claims.Add(new Claim(ClaimTypes.Role, role));

//            }

//            foreach (var roleId in roleIds)
//            {
//                claims.Add(new Claim("role_id", roleId));
//            }

//            foreach (var permission in permissions)
//            {
//                claims.Add(new Claim("permission", permission));
//            }

//            var token = new JwtSecurityToken(
//                issuer: jwtSettings["Issuer"],
//                audience: jwtSettings["Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings[ApiMessage.ExpiryMinutes])),
//                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }





