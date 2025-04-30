using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Service
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync();

        Task<PermissionDto> GetPermissionByIdAsync(string id);
        Task<bool> CreatePermissionAsync(PermissionDto permissionDto);
        Task<bool> UpdatePermissionAsync(PermissionDto permissionDto);
        Task<bool> DeletePermissionAsync(string id);
        // Task<bool> AssignPermissionToRoleAsync(RolePermissionDto dto);

        //Task<bool> IsPermissionAssignedToRoleAsync(string roleIds, string permissionId);
        Task<bool> AssignPermissionToRolesAsync(List<string> roleIds, string permissionId);

        Task<bool> AssignMultiplePermissionsToRoleAsync(string roleId, List<string> permissionsId);

        Task<IEnumerable<PermissionDto>> GetPermissionsByRoleAsync(string roleId);
        Task<bool> RemovePermissionFromRoleAsync(string roleId, string permissionId);

    }
}
