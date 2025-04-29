using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase


    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {

            _roleRepository = roleRepository;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRoles([FromQuery] string? search, [FromQuery] string? sortBy = "name", [FromQuery] bool descending = false)
        {
            var roles = await _roleRepository.GetAllRolesAsync(search, sortBy, descending);
            return Ok(roles);
        }

        // ✅ Get Role by ID
        [HttpGet("GetById/{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return role == null ? NotFound("Role not found.") : Ok(role);

        }

        // ✅ Create Role
        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Role name cannot be empty.");

            bool success = await _roleRepository.CreateRoleAsync(roleName);
            if (success)
                return Ok(new { message = "Role created successfully." });

            return Conflict(new { message = "Role already exists." });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.Id) || string.IsNullOrWhiteSpace(model.Name))
                return BadRequest("Invalid input.");

            var success = await _roleRepository.UpdateRoleAsync(model.Id, model.Name);
            if (success)
                return Ok(new { message = "Role updated successfully.", Data= model.Name });

            return Conflict(new { message = "Failed to update role." });
        }

        // ✅ Delete Role
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRole([FromQuery] string roleId)
        {
            bool success = await _roleRepository.DeleteRoleAsync(roleId);
            if (success)
                return Ok(new { message = "Role deleted successfully." });

            return NotFound(new { message = "Role not found." });
        }

       

        //[Authorize(Policy = "AssignRole")]
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] RoleAssignDto model)
        {
            var success = await _roleRepository.AssignRoleToUserAsync(model.UserId, model.RoleName);
            if (success)
                return Ok(new { message = "Role assigned successfully." });

            return NotFound(new { message = "Failed to assign role." });
           // return success ? Ok("Role assigned successfully.") : BadRequest("Failed to assign role.");
        }


        [HttpPost("RemoveRole")]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] RoleAssignDto model)
        {
            var success = await _roleRepository.RemoveRoleFromUserAsync(model.UserId, model.RoleName);
           // return success ? Ok("Role removed successfully.") : BadRequest("Failed to remove role.");
            if (success)
                return Ok(new { message = "Role removed successfully." });

            return NotFound(new { message = "Failed to remove role." });
        }

        [HttpGet("UserRoles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var roles = await _roleRepository.GetUserRolesAsync(userId);
            return Ok(roles);
        }


    }
}
