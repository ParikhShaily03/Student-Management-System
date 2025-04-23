using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Service;
namespace Student_Management_System.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(string id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null) return NotFound();
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] PermissionDto permissionDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _permissionService.CreatePermissionAsync(permissionDto);
            if (!result) return BadRequest("Failed to create permission");

            return Ok(new { message = "Permission Added successfully", result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(string id, [FromBody] PermissionDto permissionDto)
        {
            if (id != permissionDto.Id) return BadRequest("ID mismatch");

            var result = await _permissionService.UpdatePermissionAsync(permissionDto);
            if (!result) return NotFound();

            return Ok(new { message = "Permission updated successfully" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(string id)
        {
            var result = await _permissionService.DeletePermissionAsync(id);
            if (!result) return NotFound();

            return Ok(new { message = "Permission deleted successfully" });

        }

        [HttpPost("assign-to-roles")]
        public async Task<IActionResult> AssignPermissionToRoles([FromBody] RolePermissionDto rolePermissionDto)
        {
            //var permissionAssigned = await _permissionService.IsPermissionAssignedToRoleAsync(rolePermissionDto.RoleId, rolePermissionDto.PermissionId);

            //if (permissionAssigned)
            //{
            //    return BadRequest("Permission is already assigned to this role.");
            //} 

            var result = await _permissionService.AssignPermissionToRolesAsync(rolePermissionDto.RoleIds, rolePermissionDto.PermissionId);

            if (!result) return BadRequest("Failed to assign permission to roles.");

            return Ok(new { message = "Permission assigned successfully to the roles." });

        }

       
        [HttpPost("assign-multiple-permissions-to-role")]
        public async Task<IActionResult> AssignMultiplePermissionsToRole([FromBody] RolePermissionsDto dto)
        {
            var result = await _permissionService.AssignMultiplePermissionsToRoleAsync(dto.RoleId, dto.Permissions);

            if (!result)
                return BadRequest("Failed to assign permissions to the role.");

            return Ok(new { message = "Permissions successfully assigned to the role." });
        }





        //[HttpPost("remove")]
        //public async Task<IActionResult> RemovePermissionFromRole([FromBody] RolePermissionDto rolePermissionDto)
        //{
        //    var result = await _permissionService.RemovePermissionFromRoleAsync(
        //        rolePermissionDto);

        //    if (!result) return BadRequest("Failed to remove permission from role");

        //    return Ok();
        //}

        //[HttpGet("role/{roleId}")]
        //public async Task<IActionResult> GetPermissionsByRole(string roleId)
        //{
        //    var permissions = await _permissionService.GetPermissionsByRoleAsync(roleId);
        //    return Ok(permissions);
        //}

        //[HttpGet("user/{userId}")]
        //public async Task<IActionResult> GetUserPermissions(string userId)
        //{
        //    var permissions = await _permissionService.GetUserPermissionsAsync(userId);
        //    return Ok(new UserPermissionsDto { UserId = userId, Permissions = permissions.ToList() });

        //}
    }
}
