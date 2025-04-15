using Microsoft.AspNetCore.Identity;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Models;


namespace Student_Management_System.Repositories.Irepositories
{
    public interface IRoleRepository
    {
       
        Task<IEnumerable<ApplicationRole>> GetAllRolesAsync();
        Task<ApplicationRole> GetRoleByIdAsync(string roleId);
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleId);

        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<bool> RemoveRoleFromUserAsync(string UserId, string roleName);
        Task<IList<string>> GetUserRolesAsync(string UserId);

    }
}
