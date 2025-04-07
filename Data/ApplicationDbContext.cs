using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Middleware;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        //public DbSet<User> Users { get; set; }
        public DbSet<ApiLogger> ApiLoggers { get; set; }
        public DbSet<RevokedToken> RevokedTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid().ToString(), Name = "MyAdmin1", UserName = "Admin", Email = "admin@example.com", Department = "CE" },
                new User { Id = Guid.NewGuid().ToString(), Name = "MyUser1", UserName = "User", Email = "user@example.com", Department = "CE" }
            );


            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(r => r.CreatedDate).IsRequired();
                entity.Property(r => r.CreatedBy).HasMaxLength(100);
                entity.Property(r => r.DeletedDate);
                entity.Property(r => r.DeletedBy).HasMaxLength(100);
            });
        }

    }

}

