//using Microsoft.AspNetCore.Http.HttpResults;
//using System.Security.Principal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Logger
    {

        [Key]
        public int Id { get; set; }
        
        public required string  fName { get; set; }
        public required string lName { get; set; }
        public required string Message { get; set; }

        public required string Level { get; set; }

        public required DateTime TimeStamp { get; set; }
       public required Exception Ex { get; set; }



    }
}
