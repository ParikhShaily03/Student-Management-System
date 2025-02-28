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
    //[Authorize(Roles ="Admin")]
   [Authorize]
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

        //[HttpGet]
        //[Route("GetStudent/{id}")]

        //public Student GetStudent(int id)

        //{
        //    _logger.LogWarning($"Student with ID {id} not found.");
        //    return applicationDbContext.Students.Where(X => X.Id == id).FirstOrDefault();


        //}
        //option 2
        [HttpGet]
        [Route("GetStudent/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = applicationDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                _logger.LogWarning($"Student with ID {id} not found.");
                return NotFound($"Student with ID {id} not found.");

            }
            //applicationDbContext.SaveChanges();
            return Ok(student);
        }


        //[HttpPost]
        //[Route("AddStudents")]
        //public string AddStudents(Student student)
        //{

        //        string response = string.Empty;
        //        applicationDbContext.SaveChanges();


        //    return "Student Added New";

        //}
        //option 2
        [HttpPost]
        [Route("AddStudents")]
        public IActionResult AddStudents([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Invalid student data.");
                }

               // student.Id = 0; // Ensure ID is not manually assigned
                applicationDbContext.Students.Add(student);
                applicationDbContext.SaveChanges();
               // return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
                return Ok("Student Added Successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        //[HttpPut]
        //[Route("Updatestudents")]

        //public string Updatestudents(Student student)
        //{

        //    applicationDbContext.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //   // applicationDbContext.SaveChanges();
        //    return "User Updated";

        //}
        //option 2
        [HttpPut]
        [Route("Updatestudents")]
        public IActionResult Updatestudents([FromBody] Student student, int id)
        {
            if (id != student.Id)
            {
                return BadRequest("ID mismatch");
            }
            var existingStudent = applicationDbContext.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            //applicationDbContext.Entry(student).State = EntityState.Modified;
            existingStudent.Name = student.Name;
            existingStudent.Department = student.Department;
            existingStudent.Email = student.Email;

            applicationDbContext.SaveChanges(); // Save changes to DB
            return Ok("Student Updated Successfully");
        }


        //[HttpDelete]
        //[Route("DeleteStudent")]

        //public string DeleteStudent( int id)
        //{
        //    var List=  applicationDbContext.Students.Where(X => X.Id == id).FirstOrDefault();
        //    applicationDbContext.Students.Remove(List);
        //    applicationDbContext.SaveChanges();
        //    return "Student Deleted";

        //}
        //option 2
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = applicationDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            applicationDbContext.Students.Remove(student);
            applicationDbContext.SaveChanges();
            return Ok("Student Deleted Successfully");
        }

    }
}
