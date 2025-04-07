using Microsoft.AspNetCore.Identity;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleRepository(RoleManager<ApplicationRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync()
        {
            return _roleManager.Roles.Where(r => r.DeletedDate == null).ToList();
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




    }
}
