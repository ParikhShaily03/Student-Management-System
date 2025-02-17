using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Student> Students { get; set; }

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
