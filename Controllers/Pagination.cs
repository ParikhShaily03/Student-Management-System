using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pagination : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Pagination(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents(int pageNumber = 1, int pageSize = 5)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }
            var totalRecords = await _context.Students.CountAsync();

            var students = await _context.Students
                .OrderBy(s => s.Id) // Ensure consistent ordering
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)System.Math.Ceiling(totalRecords / (double)pageSize),
                Data = students
            };
            var paginatedResult = new Pagination<Student>(students, totalRecords, pageNumber, pageSize);

            return Ok(response);
        }
    }
}
