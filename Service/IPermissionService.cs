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



        // Task<bool> UserHasPermissionAsync(string userId, string permissionName);    
        //Task<bool> RemovePermissionFromRoleAsync(RolePermissionDto dto);
        //Task<IEnumerable<PermissionDto>> GetPermissionsByRoleAsync(string roleId);
        //Task<UserPermissionsDto> GetUserPermissionsAsync(string userId);
        //Task<IEnumerable<string>> GetUserPermissionsAsync(string userId);

    }
}
