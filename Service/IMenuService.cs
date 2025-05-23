

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog.Parsing;
using Student_Management_System.Data;
using Student_Management_System.Enums;
using Student_Management_System.Model;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;
using System;


public interface IMenuService
{
    Task<IEnumerable<MenuDto>> GetAllMenusAsync();
    Task<IEnumerable<Menu>> GetMenusByRoleAsync(string RoleId);
    Task<Menu?> GetMenuByIdAsync(int id);
    Task<Menu> AddMenuAsync(MenuDto menuDto);
    Task<Menu?> UpdateMenuAsync(int id, MenuDto menuDto);
    Task<bool> DeleteMenuAsync(int id);


    Task<bool> AssignRolePermissionsToMenu(MenuRoleDto dto);
    Task<bool> RemoveSpecificRolePermissions(RemoveRolePermissionsDto dto);
    Task<List<RolePermissionAssignment>> GetMenuRolePermissions(int menuId, string? roleId = null);





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
            Id = menu.Id,
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


    public async Task<bool> AssignRolePermissionsToMenu(MenuRoleDto dto)
    {
        foreach (var rp in dto.RolePermissions)
        {
            // Get all existing permissions for this menu and role
            var existing = await _context.MenuRolePermissions
                .Where(mrp => mrp.MenuId == dto.MenuId && mrp.RoleId == rp.RoleId)
                .ToListAsync();

            // Now iterate directly through the provided list of permissions
            foreach (var perm in rp.Permissions)
            {
                // Check if the permission is already assigned
                bool alreadyAssigned = existing.Any(x => x.Permission == perm);
                if (!alreadyAssigned)
                {
                    var newPermission = new MenuRolePermission
                    {
                        MenuId = dto.MenuId,
                        RoleId = rp.RoleId,
                        Permission = perm
                    };
                    await _context.MenuRolePermissions.AddAsync(newPermission);
                }
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }



    public async Task<bool> RemoveSpecificRolePermissions(RemoveRolePermissionsDto dto)
    {
        var permissions = await _context.MenuRolePermissions
            .Where(x => x.MenuId == dto.MenuId && x.RoleId == dto.RoleId)
            .ToListAsync();

        if (!permissions.Any()) return false;

        // Filter the permissions that need to be removed
        var toRemove = permissions
            .Where(p => dto.PermissionsToRemove.Contains(p.Permission))
            .ToList();

        if (!toRemove.Any()) return false;

        _context.MenuRolePermissions.RemoveRange(toRemove);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<List<RolePermissionAssignment>> GetMenuRolePermissions(int menuId, string? roleId = null)
    {
        var query = _context.MenuRolePermissions
            .Where(x => x.MenuId == menuId);

        if (!string.IsNullOrEmpty(roleId))
        {
            query = query.Where(x => x.RoleId == roleId);
        }

        var result = await query
            .GroupBy(x => x.RoleId)
            .Select(g => new RolePermissionAssignment
            {
                RoleId = g.Key,
                Permissions = g.Select(x => x.Permission).ToList()
            })
            .ToListAsync();

        return result;  // <-- Added this missing return statement
    }


}
