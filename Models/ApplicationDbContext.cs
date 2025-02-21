using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using StudentManagement.Models;

namespace StudentManagement.Model
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<ApiLogger> ApiLoggers { get; set; }
    }
}
