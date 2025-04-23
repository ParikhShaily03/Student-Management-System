using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;
using Student_Management_System.Service;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // Create a new menu
        [HttpPost("create")]
        public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
        {
            if (menu == null)
            {
                return BadRequest("Invalid menu data.");
            }

            var createdMenu = await _menuService.CreateMenuAsync(menu);
            return CreatedAtAction(nameof(CreateMenu), new { id = createdMenu.Id }, createdMenu);
        }

        // Get menus for a specific role
        [HttpGet("role/{role}")]
        public async Task<IActionResult> GetMenusForRole(string role)
        {
            var menus = await _menuService.GetMenusForRoleAsync(role);
            if (menus == null || menus.Count == 0)
            {
                return NotFound("No menus found for this role.");
            }

            return Ok(menus);
        }

        // Assign a menu to a role (after menu creation)
        [HttpPut("assign/{menuId}/{role}")]
        public async Task<IActionResult> AssignMenuToRole(int menuId, string role)
        {
            var menu = await _menuService.AssignMenuToRoleAsync(menuId, role);
            if (menu == null)
            {
                return NotFound("Menu not found.");
            }

            return Ok(menu);
        }

        // Get all menus (admin only)
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(menus);
        }
    }
}
