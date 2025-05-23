using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Student_Management_System.Data;
using Student_Management_System.Enums;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;
using Student_Management_System.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;


namespace Student_Management_System.Service
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthResponse?> LoginAsync(LoginModel model);
        Task<bool> LogoutAsync(string token);

        Task<bool> SendPasswordResetOtpAsync(string email);
        Task<bool> ResetPasswordWithOtpAsync(string email, string otp, string newPassword);

        Task<AuthResponse?> MimicUserAsync(string targetUserName, string impersonatedBy);
    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<User> userManager,
            ApplicationDbContext dbContext,
            IConfiguration configuration,
            IRoleRepository roleRepository,
            IEmailService emailService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _configuration = configuration;
            _roleRepository = roleRepository;
            _emailService = emailService;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            if (model == null) return ApiMessage.BadRequest;

            var existingEmailUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingEmailUser != null)
                return "A user with this email already exists.";

            var existingUsernameUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUsernameUser != null)
                return "A user with this username already exists.";

            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                Name = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return ApiMessage.RegistrationFailed;

            var subject = "🎉 Welcome to Our App – Enjoy Your 14-Day Free Trial!";
            var body = $@"
        <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
            <h2 style='color: #4CAF50;'>Thank you for registering, {model.Name}!</h2>
            <p>We're excited to have you join us. 🎉</p>
            <p>You now have <strong>14 days of free access</strong> to explore everything our app has to offer.</p>
            <ul>
                <li>Access premium features</li>
                <li>Manage your student data efficiently</li>
                <li>Get helpful support</li>
            </ul>
            <p>Need help? Just reply to this email — we’re here for you.</p>
            <p style='margin-top: 30px;'>Happy exploring!<br><strong>The Student Management System Team</strong></p>
        </div>";

            await _emailService.SendEmailAsync(model.Email, subject, body);

            return ApiMessage.RegistrationSuccess;
        }

        public async Task<AuthResponse?> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName) ??
                       await _userManager.FindByEmailAsync(model.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return null;

            var roles = await _roleRepository.GetUserRolesAsync(user.Id);
            var roleIds = roles.Select(r => r.Id).ToList();
            var roleNames = roles.Select(r => r.Name).ToList();

            var permissions = await _dbContext.RolePermissions
                .Where(rp => roleNames.Contains(rp.Role.Name))
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync();

            var menuPermissions = await GetUserMenuPermissionsAsync(user.Id);

            //            
            var token = GenerateJwtToken(
                user: user,
                roles: roleNames,
                roleIds: roleIds,
                permissions: permissions,
                 menuPermissions: menuPermissions
           );
         

            return new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                Roles = roleNames,
                RoleIds = roleIds,
                Permissions = permissions,
                MenuPermissions = menuPermissions

            };
        }

        private async Task<Dictionary<int, List<string>>> GetUserMenuPermissionsAsync(string userId)
        {
            // Get user's roles
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            // First get all menu permissions for these roles
            var menuPermissionsList = await _dbContext.MenuRolePermissions
                .Include(mrp => mrp.Menu)
                .Include(mrp => mrp.Role)
                .Where(mrp => userRoles.Contains(mrp.Role.Name))
                .Select(mrp => new { mrp.MenuId, mrp.Permission })
                .ToListAsync();

            // Then group in memory
            var menuPermissions = menuPermissionsList
                .GroupBy(x => x.MenuId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.Permission.ToString()).Distinct().ToList()
                );

            return menuPermissions;
        }

        public async Task<bool> LogoutAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;

            await _dbContext.RevokedTokens.AddAsync(new RevokedToken { Token = token });
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private string GenerateJwtToken(User user, IList<string> roles, IList<string> roleIds, IList<string> permissions,
    Dictionary<int, List<string>> menuPermissions,
    string? impersonatedBy = null)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName) // 👈 Add this
        };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            foreach (var roleId in roleIds)
                claims.Add(new Claim("role_id", roleId));

            foreach (var permission in permissions)
                claims.Add(new Claim("permission", permission));

            if (!string.IsNullOrEmpty(impersonatedBy))
                claims.Add(new Claim("impersonated_by", impersonatedBy));

            if (menuPermissions != null && menuPermissions.Any())
            {
                var menuPermissionsJson = JsonSerializer.Serialize(menuPermissions);
                claims.Add(new Claim("menu_permissions", menuPermissionsJson));
            }



            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings[ApiMessage.ExpiryMinutes])),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> SendPasswordResetOtpAsync(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
                return false;

            var user = await _userManager.Users
         .Where(u => u.Email == email && !u.IsDeleted)
         .FirstOrDefaultAsync();

            if (user == null)
                return false;

            var otp = new Random().Next(100000, 999999).ToString();

            user.Otp = otp;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(2); // set short expiry
            await _userManager.UpdateAsync(user);

            var subject = "🔐 Password Reset OTP";
            var body = $@"
        <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
            <h2 style='color: #FF5722;'>Password Reset Request</h2>
            <p>Hello {user.Name},</p>
            <p>Your OTP for resetting your password is:</p>
            <h3 style='color: #4CAF50;'>{otp}</h3>
            <p>This OTP will expire in 5 minutes. If you did not request this, please ignore the email.</p>
            <p>Thanks,<br/>Student Management System Team</p>
        </div>";

            await _emailService.SendEmailAsync(email, subject, body);

            return true;
        }

        public async Task<bool> ResetPasswordWithOtpAsync(string email, string otp, string newPassword)
        {
            var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);

            if (user == null)
                return false;

            // Check if OTP is valid
            if (user.Otp != otp || user.OtpExpiryTime == null || user.OtpExpiryTime < DateTime.UtcNow)
                return false;

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            if (result.Succeeded)
            {
                user.Otp = null;
                user.OtpExpiryTime = null;
                await _userManager.UpdateAsync(user);
                return true;
            }

            return false;   
        }

        public async Task<AuthResponse?> MimicUserAsync(string targetUserName, string impersonatedBy)
        {
            var targetUser = await _userManager.FindByNameAsync(targetUserName);


            if (targetUser == null || targetUser.IsDeleted)
                return null;

            var roles = await _roleRepository.GetUserRolesAsync(targetUser.Id);
            var roleIds = roles.Select(r => r.Id).ToList();
            var roleNames = roles.Select(r => r.Name).ToList();

            var permissions = await _dbContext.RolePermissions
                .Where(rp => roleNames.Contains(rp.Role.Name))
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync();

            var menuPermissions = await GetUserMenuPermissionsAsync(targetUser.Id);

            // Add impersonation claim
            var token = GenerateJwtToken(
         user: targetUser,
         roles: roleNames,
         roleIds: roleIds,
         permissions: permissions,
         menuPermissions: menuPermissions,
         impersonatedBy: impersonatedBy
     );

            return new AuthResponse
            {
                Token = token,
                UserId = targetUser.Id,
                Roles = roleNames,
                RoleIds = roleIds,
                Permissions = permissions,
                MenuPermissions = menuPermissions,
                ImpersonatedBy = impersonatedBy
            };
        }


    }
}
