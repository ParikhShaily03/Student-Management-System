using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Middleware;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<ApiLogger> ApiLoggers { get; set; }
        public DbSet<LoginModel> loginModels { get; set; }
        public DbSet<RegisterModel> RegisterModels { get; set; }
    }
}
