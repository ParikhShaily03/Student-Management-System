

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Repositories.Irepositories;


public interface IMenuService
{
    Task<IEnumerable<MenuDto>> GetAllMenusAsync();
    Task<IEnumerable<Menu>> GetMenusByRoleAsync(string RoleId);
    Task<Menu?> GetMenuByIdAsync(int id);
    Task<Menu> AddMenuAsync(MenuDto menuDto);
    Task<Menu?> UpdateMenuAsync(int id, MenuDto menuDto);
    Task<bool> DeleteMenuAsync(int id);

    Task<bool> AssignMenuToRolesAsync(int menuId, List<string> roleIds);

    Task<bool> RemoveMenuFromRolesAsync(int menuId, List<string> roleIds);

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

    public async Task<IEnumerable<MenuDto>> GetAllMenusAsync()
    {
        var menus = await _context.Menus
            .Include(m => m.MenuRoles)
                .ThenInclude(mr => mr.Role)
            .OrderBy(m => m.SortOrder)
            .ToListAsync();

        return menus.Select(menu => new MenuDto
        {
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
        }).ToList();
    }



    public async Task<IEnumerable<Menu>> GetMenusByRoleAsync(string RoleId)
    {
        return await _context.Menus
            .Where(m => m.IsActive &&
                m.MenuRoles.Any(mr => mr.Role != null && mr.Role.Id == RoleId))
            .Include(m => m.MenuRoles)
                .ThenInclude(mr => mr.Role)
            .OrderBy(m => m.SortOrder)
            .ToListAsync();
    }



    public async Task<Menu?> GetMenuByIdAsync(int id)
        {
        return await _context.Menus
    .Include(m => m.MenuRoles)
        .ThenInclude(mr => mr.Role)
    .FirstOrDefaultAsync(m => m.Id == id);
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

        int maxSortOrder = await _context.Menus.MaxAsync(m => (int?)m.SortOrder) ?? 0;
        menu.SortOrder = maxSortOrder + 1;

        // Remove role assignment from here

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

        existingMenu.Title = menuDto.Title;
        existingMenu.Url = menuDto.Url;
        existingMenu.Icon = menuDto.Icon;
        existingMenu.ParentId = menuDto.ParentId;
        existingMenu.IsActive = menuDto.IsActive;
        existingMenu.IsSubMenu = menuDto.IsSubMenu;
        existingMenu.IsExternal = menuDto.IsExternal;
        existingMenu.Target = menuDto.Target;
        existingMenu.CssClass = menuDto.CssClass;

        // Remove old role changes here

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

    public async Task<bool> AssignMenuToRolesAsync(int menuId, List<string> roleIds)
    {
        var menu = await _context.Menus
            .Include(m => m.MenuRoles)
            .FirstOrDefaultAsync(m => m.Id == menuId);

        if (menu == null) return false;

        foreach (var roleId in roleIds)
        {
            if (!menu.MenuRoles.Any(mr => mr.RoleId == roleId))
            {
                menu.MenuRoles.Add(new MenuRole
                {
                    MenuId = menuId,
                    RoleId = roleId
                });
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveMenuFromRolesAsync(int menuId, List<string> roleIds)
    {
        var menuRoles = await _context.menuRoles
            .Where(mr => mr.MenuId == menuId && roleIds.Contains(mr.RoleId))
            .ToListAsync();

        if (menuRoles.Count == 0) return false;

        _context.menuRoles.RemoveRange(menuRoles);
        await _context.SaveChangesAsync();
        return true;
    }



}
