using Student_Management_System.Models.DTOs;
using Student_Management_System.Models;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionRepository.GetAllPermissionsAsync();
            return permissions.Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });
        }

        public async Task<PermissionDto> GetPermissionByIdAsync(string id)
        {
            var permission = await _permissionRepository.GetPermissionByIdAsync(id);
            if (permission == null) return null;

            return new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };
        }

        public async Task<bool> CreatePermissionAsync(PermissionDto permissionDto)
        {
            var permission = new Permission
            {
                Id = permissionDto.Id,
                Name = permissionDto.Name,
                Description = permissionDto.Description
            };
            return await _permissionRepository.CreatePermissionAsync(permission);
        }

        public async Task<bool> UpdatePermissionAsync(PermissionDto permissionDto)
        {
            var permission = new Permission
            {
                Id = permissionDto.Id,
                Name = permissionDto.Name,
                Description = permissionDto.Description
            };
            return await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async Task<bool> DeletePermissionAsync(string id)
        {
            return await _permissionRepository.DeletePermissionAsync(id);
        }

        public async Task<bool> AssignPermissionToRoleAsync(RolePermissionDto dto)
        {
            return await _permissionRepository.AssignPermissionToRoleAsync(dto.RoleId, dto.PermissionId);
        }
    }
}
        //public async
        //Task<bool> RemovePermissionFromRoleAsync(RolePermissionDto dto)
        //{
        //    return await
        //        }
