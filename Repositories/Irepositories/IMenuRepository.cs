//using Microsoft.EntityFrameworkCore;
//using Student_Management_System.Data;
//using Student_Management_System.Models;

//namespace Student_Management_System.Repositories.Irepositories
//{
//    public interface IMenuRepository
//    {
//        Task<IEnumerable<Menu>> GetMenusByRoleAsync(string role);
//        Task<Menu> CreateMenuAsync(Menu menu);
//    }

//    public class MenuRepository : IMenuRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public MenuRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Menu>> GetMenusByRoleAsync(string role)
//        {
//            return await _context.Menus
//                .Where(m => m.IsActive && m.Role == role)
//                .ToListAsync();
//        }

//        public async Task<Menu> CreateMenuAsync(Menu menu)
//        {
//            _context.Menus.Add(menu);
//            await _context.SaveChangesAsync();
//            return menu;
//        }
//    }

//}

