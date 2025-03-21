using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Controllers
{
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
            return role == null ? Ok(ApiMassage.NotFound) : Ok(role);
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


    }
}
