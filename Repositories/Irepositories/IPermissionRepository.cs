using Student_Management_System.Models;

namespace Student_Management_System.Repositories.Irepositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(string id);
        Task<bool> CreatePermissionAsync(Permission permission);
        Task<bool> UpdatePermissionAsync(Permission permission);
        Task<bool> DeletePermissionAsync(string id);
        Task<bool> AssignPermissionToRoleAsync(string roleId, string permissionId);
        //Task<bool> RemovePermissionFromRoleAsync(string roleId, string permissionId);
        Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(string roleId);
        Task<IEnumerable<string>> GetUserPermissionsAsync(string userId);
    }
}
