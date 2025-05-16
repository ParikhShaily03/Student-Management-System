using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly IRoleRepository _roleRepository;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ApplicationDbContext dbContext, IRoleRepository roleRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _roleRepository = roleRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return Ok(ApiMessage.BadRequest);

            User usernew = new User
            {
                Email = model.Email,
                UserName = model.UserName, // Ensuring UserName is set
                Name = model.Name // Or model.Name if Name is provided in the DTO
            };
            var result = await _userManager.CreateAsync(usernew, model.Password);

            if (!result.Succeeded)
                return Ok(ApiMessage.RegistrationFailed);

            // await _userManager.AddToRoleAsync(usernew, model.Role);
            return Ok(new { message = ApiMessage.RegistrationSuccess });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName)
         ?? await _userManager.FindByEmailAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(ApiMessage.LoginFailed);

            // var roles = await _userManager.GetRolesAsync(user);
            var roles = await _roleRepository.GetUserRolesAsync(user.Id);

            var permissionIds = await _dbContext.RolePermissions
             .Where(rp => roles.Contains(rp.Role.Name))
             .Select(rp => rp.Permission.Name)
             .Distinct()
             .ToListAsync();

            //var token = GenerateJwtToken(user, roles.FirstOrDefault() ?? "User");
            var token = GenerateJwtToken(user, roles, permissionIds);
            // var menus = _dbContext.Menus.OrderBy(m => m.SortOrder).ToList();
            //return Ok(new AuthResponse { Token = token}, ApiMassage.LoginSuccess);
            return Ok(new
            {
                message = ApiMessage.LoginSuccess,
                data = new AuthResponse
                {

                    Token = token,
                    UserId = user.Id,
                    Roles = roles.ToList(),
                    Permissions = permissionIds.ToList(),
                    //Menus = menus.ToList(),
                }
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                return BadRequest("Invalid token");

            // Save the token to the revoked tokens table
            await _dbContext.RevokedTokens.AddAsync(new RevokedToken { Token = token });
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Logout successful" });
        }




        private string GenerateJwtToken(User user, IList<string> roles, IList<string> permissions)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        new Claim(JwtRegisteredClaimNames.Email, user.Email)
    };

            // Add all roles dynamically
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings[ApiMessage.ExpiryMinutes])),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}

