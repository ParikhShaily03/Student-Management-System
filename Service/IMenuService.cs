//using Microsoft.EntityFrameworkCore;
//using Student_Management_System.Data;
//using Student_Management_System.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


//namespace Student_Management_System.Service
//{
//    public interface IMenuService
//    {

//        Task<Menu> CreateMenuAsync(Menu menu);
//        Task<List<Menu>> GetMenusForRoleAsync(string role);
//        Task<Menu> AssignMenuToRoleAsync(int menuId, string role);
//        Task<List<Menu>> GetAllMenusAsync();


//    }
//    public class MenuService : IMenuService
//    {
//        private readonly ApplicationDbContext _context;

//        public MenuService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Create new menu
//        public async Task<Menu> CreateMenuAsync(Menu menu)
//        {
//            _context.Menus.Add(menu);
//            await _context.SaveChangesAsync();
//            return menu;
//        }

//        // Get menus for a specific role
//        public async Task<List<Menu>> GetMenusForRoleAsync(string role)
//        {
//            return await _context.Menus
//                                 .Where(m => m.Role == role && m.IsActive)
//                                 .ToListAsync();
//        }

//        // Assign an existing menu to a role
//        public async Task<Menu> AssignMenuToRoleAsync(int menuId, string role)
//        {
//            var menu = await _context.Menus.FindAsync(menuId);
//            if (menu == null)
//                return null;

//            menu.Role = role;
//            await _context.SaveChangesAsync();
//            return menu;
//        }

//        // Get all menus (for admin, etc.)
//        public async Task<List<Menu>> GetAllMenusAsync()
//        {
//            return await _context.Menus.ToListAsync();
//        }
//    }


//}

using System;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;

public interface IMenuService
{
    Task<IEnumerable<Menu>> GetAllMenusAsync();
    Task<Menu?> GetMenuByIdAsync(int id);
    Task<Menu> AddMenuAsync(Menu menu);
    Task<Menu?> UpdateMenuAsync(int id, Menu menu);
    Task<bool> DeleteMenuAsync(int id);
}

public class MenuService : IMenuService
{
    private readonly ApplicationDbContext _context;

    public MenuService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Menu>> GetAllMenusAsync()
    {
        return await _context.Menus.OrderBy(m => m.SortOrder).ToListAsync();
    }

    public async Task<Menu?> GetMenuByIdAsync(int id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task<Menu> AddMenuAsync(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu?> UpdateMenuAsync(int id, Menu updatedMenu)
    {
        var existingMenu = await _context.Menus.FindAsync(id);
        if (existingMenu == null) return null;

        _context.Entry(existingMenu).CurrentValues.SetValues(updatedMenu);
        await _context.SaveChangesAsync();
        return updatedMenu;
    }

    public async Task<bool> DeleteMenuAsync(int id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu == null) return false;

        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
        return true;
    }
}
