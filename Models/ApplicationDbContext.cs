//using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Logger> Loggers { get; set; }
        //public DbSet<Login> Login { get; set; }
        //public DbSet<Register> Register { get; set; }

    }
}
