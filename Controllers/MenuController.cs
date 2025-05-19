
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Enums;
using Student_Management_System.Middleware;

[ApiController]
//[Authorize]

[Route("api/[controller]")]

public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("GetAllMenu")]
    [HasPermission(PermissionEnum.AccessPermission)]

    public async Task<IActionResult> GetMenus()
    {
        var menus = await _menuService.GetAllMenusAsync();
        return Ok(menus);
    }

    [HttpGet("GetMenusByRole/{RoleId}")]
    public async Task<IActionResult> GetMenusByRole(string RoleId)
    {
        var menus = await _menuService.GetMenusByRoleAsync(RoleId);
        return Ok(menus);
    }


    [HttpGet("{id}")]
    [HasPermission(PermissionEnum.AccessPermission)]
    public async Task<IActionResult> GetMenu(int id)
    {
        var menu = await _menuService.GetMenuByIdAsync(id);
        if (menu == null) return NotFound();
        return Ok(menu);
    }

    [HttpPost("CreateMenu")]
    [HasPermission(PermissionEnum.AccessPermission)]
    public async Task<IActionResult> CreateMenu([FromBody] MenuDto menuDto)
    {
        var createdMenu = await _menuService.AddMenuAsync(menuDto);
        return Ok(createdMenu);
    }

    [HttpPut("UpdateMenu")]
     [HasPermission(PermissionEnum.AccessPermission)]

    public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuDto menuDto)
    {
        var updated = await _menuService.UpdateMenuAsync(id, menuDto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }


    [HttpDelete("DeleteMenu")]
    [HasPermission(PermissionEnum.AccessPermission)]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var deleted = await _menuService.DeleteMenuAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpPost("AssignMenuToRole")]
    [HasPermission(PermissionEnum.AccessPermission)]
    public async Task<IActionResult> AssignMenuToRoles([FromBody] MenuRoleDto dto)
    {
        var result = await _menuService.AssignMenuToRolesAsync(dto.MenuId, dto.RoleIds);
        if (!result) return BadRequest("Assignment failed.");
        return Ok("Menu assigned to roles.");
    }

    [HttpPost("RemoveMenuFromRole")]
    [HasPermission(PermissionEnum.AccessPermission)]
    public async Task<IActionResult> RemoveMenuFromRoles([FromBody] MenuRoleDto dto)
    {
        var result = await _menuService.RemoveMenuFromRolesAsync(dto.MenuId, dto.RoleIds);
        if (!result) return BadRequest("Removal failed.");
        return Ok("Menu removed from roles.");
    }



}
