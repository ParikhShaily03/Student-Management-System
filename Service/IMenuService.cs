using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Student_Management_System.Service
{
    public interface IMenuService
    {

        Task<Menu> CreateMenuAsync(Menu menu);
        Task<List<Menu>> GetMenusForRoleAsync(string role);
        Task<Menu> AssignMenuToRoleAsync(int menuId, string role);
        Task<List<Menu>> GetAllMenusAsync();


    }
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create new menu
        public async Task<Menu> CreateMenuAsync(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        // Get menus for a specific role
        public async Task<List<Menu>> GetMenusForRoleAsync(string role)
        {
            return await _context.Menus
                                 .Where(m => m.Role == role && m.IsActive)
                                 .ToListAsync();
        }

        // Assign an existing menu to a role
        public async Task<Menu> AssignMenuToRoleAsync(int menuId, string role)
        {
            var menu = await _context.Menus.FindAsync(menuId);
            if (menu == null)
                return null;

            menu.Role = role;
            await _context.SaveChangesAsync();
            return menu;
        }

        // Get all menus (for admin, etc.)
        public async Task<List<Menu>> GetAllMenusAsync()
        {
            return await _context.Menus.ToListAsync();
        }
    }


}
