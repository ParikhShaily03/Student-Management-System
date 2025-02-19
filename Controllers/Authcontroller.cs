using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Student_Management_System.Data;
using Student_Management_System.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace Student_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid request data.");
            }

            var response = await _authenticationService.Login(request);
            if (response == "Invalid login attempt")
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Student_Management_System.Models.RegisterRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid request data.");
            }

            var response = await _authenticationService.Register(request);
            //if (response.StartsWith("Registration failed"))
            //{
            //    return BadRequest(response);
            //}
            var strResponse = response as string;
            if (strResponse != null && strResponse.StartsWith("Registration failed"))
            {
                return BadRequest(strResponse);
            }

            return Ok(response);
        }
    }
}

