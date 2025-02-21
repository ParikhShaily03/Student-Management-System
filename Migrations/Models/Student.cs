using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Migrations.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Department { get; set; }




    }
}
