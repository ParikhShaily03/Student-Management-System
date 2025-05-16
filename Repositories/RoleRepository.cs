using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Model;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleRepository(RoleManager<ApplicationRole> roleManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync(string? search, string? sortBy, bool descending)
        {
            var query = _roleManager.Roles
                .Where(r => r.DeletedDate == null);

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(r => r.Name.ToLower().Contains(search));
            }

            // Apply sorting
            query = sortBy?.ToLower() switch
            {
                "createddate" => descending ? query.OrderByDescending(r => r.CreatedDate) : query.OrderBy(r => r.CreatedDate),
                "name" or _ => descending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name),
            };

            var result = await query
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync(); // Use async EF Core call

            return result;
        }


        public async Task<ApplicationRole> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return false;

            var role = new ApplicationRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(), // Required for case-insensitive lookups
                CreatedBy = "Admin", // Replace with actual user if available
                CreatedDate = DateTime.Now

            };

            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleAsync(string roleId, string newRoleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return false;

            if (await _roleManager.RoleExistsAsync(newRoleName))
                return false;

            role.Name = newRoleName;
            role.NormalizedName = newRoleName.ToUpper();
            role.CreatedDate = DateTime.Now;
            // role.UpdatedBy = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "System";

            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return false;

            var currentUser = _httpContextAccessor.HttpContext?.User.Identity?.Name;

            role.DeletedBy = currentUser ?? "Admin";  // Fallback to "System" if user is null
            role.DeletedDate = DateTime.Now;


            var updateResult = await _roleManager.UpdateAsync(role);
            return updateResult.Succeeded;
        }

        public async Task<bool> AssignRoleToUserAsync(string Id, string roleName)
        {
            Id = Id.Trim().ToLower();
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null || !await _roleManager.RoleExistsAsync(roleName))
                return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }


        public async Task<bool> RemoveRoleFromUserAsync(string Id, string roleName)
        {

            Id = Id.Trim().ToLower();
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null || !await _roleManager.RoleExistsAsync(roleName))
                return false;

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetUserRolesAsync(string Id)
        {
            Id = Id.Trim().ToLower();
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                return new List<string>();

            return await _userManager.GetRolesAsync(user);
        }



    }
}
