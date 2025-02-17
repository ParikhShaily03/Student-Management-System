using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Student_Management_System.Models
{
    public class Logger
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Massage { get; set; }
      
        public string Level { get; set; }

        public DateTime timeStamp { get; set; }
       public Exception ex { get; set; }



    }
}
