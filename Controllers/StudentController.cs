using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
      

        private readonly ApplicationDbContext applicationDbContext;
        public StudentController(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;

        [HttpGet]

        [Route("GetStudents")]

        public List<Student> GetStudents()
        {
            return applicationDbContext.Students.ToList();
        }
     



        [HttpGet]
        [Route("GetStudent/{id}")]

        public Student GetStudent(int id)
          
        {
            
                return applicationDbContext.Students.Where(X => X.Id == id).FirstOrDefault();
            
         
        }

        [HttpPost]
        [Route("AddStudents")]
        public string AddStudents(Student student)
        {
            
                string response = string.Empty;
                applicationDbContext.Students.Add(student);
                applicationDbContext.SaveChanges();
             
           
            return "Student Added New";

        }
        
        [HttpPut]
        [Route("Updatestudents")]

        public string Updatestudents(Student student)
        {

            applicationDbContext.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // applicationDbContext.SaveChanges();
            return "User Updated";

        }

        [HttpDelete]
        [Route("DeleteStudent")]
        
        public string DeleteStudent( int id)
        {
            var List=  applicationDbContext.Students.Where(X => X.Id == id).FirstOrDefault();
            applicationDbContext.Students.Remove(List);
            applicationDbContext.SaveChanges();
            return "Student Deleted";

        }
    }
}
