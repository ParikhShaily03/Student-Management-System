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
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
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
            return success ? Ok("Role created successfully.") : BadRequest("Role already exists.");
        }

        // ✅ Delete Role
        [HttpDelete("Delete/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            bool success = await _roleRepository.DeleteRoleAsync(roleId);
            return success ? Ok("Role deleted successfully.") : NotFound("Role not found.");
        }

        //[HttpPost("AssignRole")]
        //public async Task<IActionResult> AssignRoleToUser([FromQuery] string userId , [FromQuery] string roleName)
        //{
        //    var success = await _roleRepository.AssignRoleToUserAsync(userId, roleName);
        //    return success ? Ok("Role assigned successfully.") : BadRequest("Failed to assign role.");
        //}

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] RoleAssignDto model)
        {
            var success = await _roleRepository.AssignRoleToUserAsync(model.UserId, model.RoleName);
            return success ? Ok("Role assigned successfully.") : BadRequest("Failed to assign role.");
        }


        [HttpPost("RemoveRole")]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] RoleAssignDto model)
        {
            var success = await _roleRepository.RemoveRoleFromUserAsync(model.UserId, model.RoleName);
            return success ? Ok("Role removed successfully.") : BadRequest("Failed to remove role.");
        }

        [HttpGet("UserRoles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var roles = await _roleRepository.GetUserRolesAsync(userId);
            return Ok(roles);
        }


    }
}
