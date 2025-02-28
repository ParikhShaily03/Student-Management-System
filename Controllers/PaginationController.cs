using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        // Sample endpoint to demonstrate pagination.
        [HttpGet]
        public IActionResult GetPagedData([FromQuery] PaginationParameters paginationParameters)
        {
            // Example data: list of numbers 1 to 100.
            var data = Enumerable.Range(1, 100).ToList();
            var pagedData = data
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();

            var result = new PagedResult<int>
            {
                Items = pagedData,
                TotalCount = data.Count
            };

            return Ok(result);
        }
    }
}
