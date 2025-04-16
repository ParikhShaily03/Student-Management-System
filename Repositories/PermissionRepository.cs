using Microsoft.AspNetCore.Identity;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Repositories.Irepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<User> _userManager;
        //private readonly IPermissionRepository _permissionRepository;
        //private readonly IMapper _mapper;

        public PermissionRepository(
            ApplicationDbContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<User> userManager
            //IPermissionRepository permissionRepository,
           /* IMapper mapper*/)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            //_permissionRepository = permissionRepository;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(string id)
        {
            return await _context.Permissions.FindAsync(id);
        }

        public async Task<bool> CreatePermissionAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePermissionAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePermissionAsync(string id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null) return false;

            _context.Permissions.Remove(permission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignPermissionToRoleAsync(string roleId, string permissionId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var permission = await _context.Permissions.FindAsync(permissionId);

            if (role == null || permission == null) return false;

            var existing = await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

            if (existing != null) return true; // Already exists

            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };

            await _context.RolePermissions.AddAsync(rolePermission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemovePermissionFromRoleAsync(string roleId, string permissionId)
        {
            var rolePermission = await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

            if (rolePermission == null) return false;

            _context.RolePermissions.Remove(rolePermission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(string roleId)
        {
            return await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Include(rp => rp.Permission)
                .Select(rp => rp.Permission)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUserPermissionsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Enumerable.Empty<string>();

            var userRoles = await _userManager.GetRolesAsync(user);

            var permissions = await _context.RolePermissions
            .Include(rp => rp.Role) // 👈 This is needed
            .Include(rp => rp.Permission)
            .Where(rp => userRoles.Contains(rp.Role.Name)) // Now safe to access rp.Role.Name
            .Select(rp => rp.Permission.Name)
            .Distinct()
            .ToListAsync();

            return permissions;
        }
    }
}
