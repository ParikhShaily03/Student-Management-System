using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;

namespace Student_Management_System.Migrations.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

    }
    //public class AboutModel : PageModel
    //{
    //    private readonly ILogger _logger;
    //    public AboutModel(ILogger<AboutModel> logger)
    //    {
    //        _logger = logger;
    //    }
    //    public void OnGet()

    //    {
    //        _logger.LogInformation("About page Visited {DT}",
    //            DateTime.UtcNow.ToLongTimeString());
    //    }
    ////}
}
