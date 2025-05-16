

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Repositories.Irepositories;


public interface IMenuService
{
    Task<IEnumerable<Menu>> GetAllMenusAsync();
    Task<Menu?> GetMenuByIdAsync(int id);
    Task<Menu> AddMenuAsync(MenuDto menuDto);
    Task<Menu?> UpdateMenuAsync(int id, MenuDto menuDto);
    Task<bool> DeleteMenuAsync(int id);

}

public class MenuService : IMenuService
{
    private readonly ApplicationDbContext _context;
    private readonly IRoleRepository _roleRepository;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public MenuService(ApplicationDbContext context, IRoleRepository roleRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _roleRepository = roleRepository;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<Menu>> GetAllMenusAsync()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        if (user == null)
            return new List<Menu>();

        var userRoles = await _userManager.GetRolesAsync(user);

        var allMenus = await _context.Menus
      .Where(m => m.IsActive)
      .Include(m => m.MenuRoles)
          .ThenInclude(mr => mr.Role)
      .OrderBy(m => m.SortOrder)
      .ToListAsync();

        var filteredMenus = allMenus.Where(m =>
    m.MenuRoles != null && m.MenuRoles.Any(mr =>
        mr.Role != null && !string.IsNullOrEmpty(mr.Role.Name) &&
        userRoles.Any(userRole =>
            string.Equals(userRole.Trim(), mr.Role.Name.Trim(), StringComparison.OrdinalIgnoreCase)
        )
    )
);
        return filteredMenus;
    }


    public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            return await _context.Menus.FindAsync(id);
        }

    public async Task<Menu> AddMenuAsync(MenuDto menuDto)
    {
        var menu = new Menu
        {
            Title = menuDto.Title,
            Url = menuDto.Url,
            Icon = menuDto.Icon,
            ParentId = menuDto.ParentId,
            IsActive = menuDto.IsActive,
            IsSubMenu = menuDto.IsSubMenu,
            IsExternal = menuDto.IsExternal,
            Target = menuDto.Target,
            CssClass = menuDto.CssClass
        };

        // Set sort order
        int maxSortOrder = await _context.Menus.MaxAsync(m => (int?)m.SortOrder) ?? 0;
        menu.SortOrder = maxSortOrder + 1;

        // Add MenuRoles
        if (menuDto.RoleIds?.Any() == true)
        {
            foreach (var roleId in menuDto.RoleIds)
            {
                menu.MenuRoles.Add(new MenuRole { RoleId = roleId });
            }
        }

        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();

        return menu;
    }



    public async Task<Menu?> UpdateMenuAsync(int id, MenuDto menuDto)
    {
        var existingMenu = await _context.Menus
            .Include(m => m.MenuRoles)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (existingMenu == null) return null;

        // Update menu fields
        existingMenu.Title = menuDto.Title;
        existingMenu.Url = menuDto.Url;
        existingMenu.Icon = menuDto.Icon;
        existingMenu.ParentId = menuDto.ParentId;
        existingMenu.IsActive = menuDto.IsActive;
        existingMenu.IsSubMenu = menuDto.IsSubMenu;
        existingMenu.IsExternal = menuDto.IsExternal;
        existingMenu.Target = menuDto.Target;
        existingMenu.CssClass = menuDto.CssClass;

        // Remove old roles
        _context.menuRoles.RemoveRange(existingMenu.MenuRoles);

        // Add new roles
        if (menuDto.RoleIds?.Any() == true)
        {
            foreach (var roleId in menuDto.RoleIds)
            {
                existingMenu.MenuRoles.Add(new MenuRole
                {
                    RoleId = roleId
                });
            }
        }

        await _context.SaveChangesAsync();
        return existingMenu;
    }


    public async Task<bool> DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null) return false;

        // Get the SortOrder of the menu to delete
        int deletedSortOrder = menu.SortOrder;

        // Remove the menu
        _context.Menus.Remove(menu);

        // Get all menus that come after this one in SortOrder
        var menusToUpdate = await _context.Menus
            .Where(m => m.SortOrder > deletedSortOrder)
            .ToListAsync();

        // Shift all subsequent menus' SortOrder down by 1
        foreach (var m in menusToUpdate)
        {
            m.SortOrder -= 1;
        }

        await _context.SaveChangesAsync();

        return true;
    }



}
