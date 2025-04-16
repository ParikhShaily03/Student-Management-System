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

            return CreatedAtAction(nameof(GetPermissionById), new { id = permissionDto.Id }, permissionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(string id, [FromBody] PermissionDto permissionDto)
        {
            if (id != permissionDto.Id) return BadRequest("ID mismatch");

            var result = await _permissionService.UpdatePermissionAsync(permissionDto);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(string id)
        {
            var result = await _permissionService.DeletePermissionAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignPermissionToRole([FromBody] RolePermissionDto rolePermissionDto)
        {
            var result = await _permissionService.AssignPermissionToRoleAsync(
                rolePermissionDto);

            if (!result) return BadRequest("Failed to assign permission to role");

            return Ok();
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
