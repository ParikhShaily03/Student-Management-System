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

        //public async Task<bool> AssignPermissionToRoleAsync(RolePermissionDto dto)
        //{
        //    return await _permissionRepository.AssignPermissionToRoleAsync(dto.RoleIds.ToString(), dto.PermissionId);
        //}

        public async Task<bool> AssignPermissionToRolesAsync(List<string> roleIds, string permissionId)
        {
            bool allAssigned = true;
            foreach (var roleId in roleIds)
            {
                var result = await _permissionRepository.AssignPermissionToRoleAsync(roleId, permissionId);
                if (!result)
                {
                    allAssigned = false;
                    // Optionally, handle partial failures here
                }
            }
            return allAssigned;
        }
        public async Task<bool> AssignMultiplePermissionsToRoleAsync(string roleId, List<string> permissionsId)
        {
            bool allAssigned = true;
            foreach (var permissionId in permissionsId)
            {
                var result = await _permissionRepository.AssignPermissionToRoleAsync(roleId, permissionId);
                if (!result)
                {
                    allAssigned = false;
                    // Optionally, handle partial failures here
                }
            }
            return allAssigned;
        }


        public async Task<IEnumerable<PermissionDto>> GetPermissionsByRoleAsync(string roleId)
        {
            var permissions = await _permissionRepository.GetPermissionsByRoleAsync(roleId);
            return permissions.Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category
            });
        }

        public async Task<bool> RemovePermissionFromRoleAsync(string roleId, string permissionId)
        {
            return await _permissionRepository.RemovePermissionFromRoleAsync(roleId, permissionId);
        }



    }
}
       