
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenus()
    {
        var menus = await _menuService.GetAllMenusAsync();
        return Ok(menus);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenu(int id)
    {
        var menu = await _menuService.GetMenuByIdAsync(id);
        if (menu == null) return NotFound();
        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
    {
        var createdMenu = await _menuService.AddMenuAsync(menu);
        return CreatedAtAction(nameof(GetMenu), new { id = createdMenu.Id }, createdMenu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenu(int id, [FromBody] Menu menu)
    {
        var updated = await _menuService.UpdateMenuAsync(id, menu);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var deleted = await _menuService.DeleteMenuAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
