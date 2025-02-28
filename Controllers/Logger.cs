using Microsoft.AspNetCore.Mvc;

namespace Student_Management_System.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class Logger : ControllerBase
    {
        private readonly ILogger<Logger> _logger;

        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }

        [HttpGet("test-log")]
        public IActionResult TestLog()
        {
            _logger.LogInformation("This is a test log message!");
            return Ok("Log message written to database.");
        }
    }
}
