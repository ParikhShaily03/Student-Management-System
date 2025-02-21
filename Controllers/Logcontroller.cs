using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        //public IActionResult GetLogs()
        //{
        //    var logs = ApiLogger.GetLogs();
        //    return Ok(logs);
        //}
        public IActionResult Get()
        {
            Log.Information("Received a GET request at /api/test");
            return Ok("Serilog is working!");
        }
    }
}
