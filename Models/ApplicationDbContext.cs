using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        
        
        }   
        DbSet<Student> Students { get; set; }   

    }
}
