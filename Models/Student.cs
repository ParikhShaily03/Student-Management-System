using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Student
    {
        [Key]
        public required int Id { get; set; }
        public required string Fname { get; set; }  
        public required string Lname {  get; set; }
        public required string Department { get; set; }
        


    }
}
