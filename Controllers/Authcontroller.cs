using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.IdentityModel.Tokens;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;

//using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return Ok(ApiMassage.BadRequest);

            User usernew = new User
            {
                Email = model.Email,
                UserName = model.UserName, // Ensuring UserName is set
                Name = model.Name // Or model.Name if Name is provided in the DTO
            };
            var result = await _userManager.CreateAsync(usernew, model.Password);

            if (!result.Succeeded)
                return Ok(ApiMassage.RegistrationFailed);

           // await _userManager.AddToRoleAsync(usernew, model.Role);
            return Ok(ApiMassage.RegistrationSuccess);
            }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
            {
            var user = await _userManager.FindByNameAsync(model.UserName)
         ?? await _userManager.FindByEmailAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Ok(ApiMassage.Unauthorized);

            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles.FirstOrDefault() ?? "User");


           //return Ok(new AuthResponse { Token = token}, ApiMassage.LoginSuccess);
            return Ok(new
            {
                message = ApiMassage.LoginSuccess,
                data = new AuthResponse { Token = token }
            });
        }

        private string GenerateJwtToken(User user, string role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
               new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
               claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings[ApiMassage.ExpiryMinutes])),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

