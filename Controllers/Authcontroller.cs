﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;

using System;
using System.Threading.Tasks;
//using Student_Management_System.Data;
using Student_Management_System.Services;
//using Student_Management_System.Models;


using System.Threading.Tasks;
using Student_Management_System.Data.DTO;
//using Microsoft.AspNetCore.Identity.Data;

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
        public async Task<IActionResult> Login([FromBody] Student_Management_System.Data.LoginRequest request)

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


        //var identityRequest = new Microsoft.AspNetCore.Identity.Data.LoginRequest

        //{
        //    Email = request.Email;
        //    Password = request.Password;
        //};
        //var response = await _authenticationService.Login(identityRequest);


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Data.DTO.RegisterRequest request)
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