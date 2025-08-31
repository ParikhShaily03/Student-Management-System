
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Enums;
using Student_Management_System.Middleware;

[ApiController]
[Authorize]

[Route("api/[controller]")]

public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("GetAllMenu")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.View)]

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
    [HasMenuPermission("/MenuManagement", PermissionEnum.View)]
    public async Task<IActionResult> GetMenu(int id)
    {
        var menu = await _menuService.GetMenuByIdAsync(id);
        if (menu == null) return NotFound();

        var dto = new MenuDto
        {
            Id=menu.Id,
            Title = menu.Title,
            Url = menu.Url,
            Icon = menu.Icon,
            ParentId = menu.ParentId,
            IsActive = menu.IsActive,
            IsSubMenu = menu.IsSubMenu,
            IsExternal = menu.IsExternal,
            Target = menu.Target,
            CssClass = menu.CssClass,
            AssignedRoleIds = menu.MenuRoles.Select(mr => mr.RoleId).ToList(),
            AssignedRoleNames = menu.MenuRoles.Select(mr => mr.Role.Name).ToList()
        };

        return Ok(dto);
    }


    [HttpPost("CreateMenu")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.Create)]
    public async Task<IActionResult> CreateMenu([FromBody] MenuDto menuDto)
    {
        var createdMenu = await _menuService.AddMenuAsync(menuDto);
        return Ok(createdMenu);
    }

    [HttpPut("UpdateMenu")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.Edit)]

    public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuDto menuDto)
    {
        var updated = await _menuService.UpdateMenuAsync(id, menuDto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("DeleteMenu/{id}")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.Delete)]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var deleted = await _menuService.DeleteMenuAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpPost("AssignRolePermissionsToMenu")]

    [HasMenuPermission("/MenuManagement", PermissionEnum.AccessPermission)]
    public async Task<IActionResult> AssignRolePermissions([FromBody] MenuRoleDto dto)
    {
        var result = await _menuService.AssignRolePermissionsToMenu(dto);
        if (!result) return BadRequest("Failed to assign permissions");
      //  return Ok("Permissions assigned successfully");
        return Ok(new { message = "Permissions assigned successfully" });

    }

    [HttpPost("RemoveRolePermissionsFromMenu")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.AccessPermission)]
    public async Task<IActionResult> RemoveRolePermissionsFromMenu([FromBody] RemoveRolePermissionsDto dto)
    {
        var result = await _menuService.RemoveSpecificRolePermissions(dto);
        if (!result) return NotFound("No matching permissions found to remove.");
        return Ok(new { message= "Permissions removed successfully." });
    }


  
    [HttpGet("GetRolePermissions/{menuId}")]
    [HasMenuPermission("/MenuManagement", PermissionEnum.View)]
    public async Task<IActionResult> GetRolePermissions(int menuId, [FromQuery] string? roleId = null)
    {
        var permissions = await _menuService.GetMenuRolePermissions(menuId, roleId);
        return Ok(permissions);
    }








}
