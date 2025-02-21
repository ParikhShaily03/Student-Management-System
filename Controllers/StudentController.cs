using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.EntityFrameworkCore;
//using Student_Management_System.Models;
//using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Model;
using Microsoft.AspNetCore.Authorization;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class StudentController : ControllerBase
    {
      

        private readonly ApplicationDbContext applicationDbContext;
        private readonly ILogger<StudentController> _logger;

        // public StudentController(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;
        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            applicationDbContext = context;
            _logger = logger;
        }

        [HttpGet]

        [Route("GetStudents")]


        public List<Student> GetStudents()
        {
            _logger.LogInformation("Fetching students...");
            return applicationDbContext.Students.ToList();
        }
     



        [HttpGet]
        [Route("GetStudent/{id}")]

        public Student GetStudent(int id)
          
        {
            _logger.LogWarning($"Student with ID {id} not found.");
            return applicationDbContext.Students.Where(X => X.Id == id).FirstOrDefault();
            
         
        }

        [HttpPost]
        [Route("AddStudents")]
        public string AddStudents(Student student)
        {
            
                string response = string.Empty;
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
