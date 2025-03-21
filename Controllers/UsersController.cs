using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.EntityFrameworkCore;
//using Student_Management_System.Models;
//using StudentManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Repositories;
using Student_Management_System.Repositories.Irepositories;
using System.Security.Claims;
using Student_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
  // [Authorize]
    public class UsersController : ControllerBase
    {
      

        private readonly ApplicationDbContext applicationDbContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IUser _User;
      
        // public StudentController(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;
        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger, IUser User)
        {
            applicationDbContext = context;
            _logger = logger;
            _User = User ?? throw new ArgumentNullException(nameof(User));
        }


        [HttpGet]

        [Route("GetUsers")]

        //[HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var Users = await _User.GetAllAsync();
            //return Ok(Users);
            return Ok(new { Message = ApiMassage.Success, data= Users});
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _User.GetByIdAsync(id);
            if (user == null)
            {
                return Ok(ApiMassage.NotFound);
            }

            //return Ok(user);
            return Ok(new { Message = ApiMassage.Success, data = user });


        }


        [HttpPost("UpsertUser")]
        public async Task<IActionResult> UpsertUser([FromBody] Add_EditDTO userDto, Guid? ID)
        {
            if (userDto == null)
                return Ok(ApiMassage.BadRequest);

            try
            {
                var result = await _User.UpsertUserAsyc(userDto, ID);
                return Ok(new { Message = ApiMassage.Updated, User = result });
            }
            catch (Exception ex)
            {
                return Ok(ApiMassage.BadRequest);
            }
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Ok(ApiMassage.BadRequest);
            }

            var isDeleted = await _User.DeleteAsync(id);
            if (!isDeleted)
            {
                return Ok(ApiMassage.InternalServerError);
            }

            return Ok(ApiMassage.Deleted);
        }


        ////working

        ////option 2
        //[HttpPost]
        //[Route("AddStudents")]
        //public async Task<IActionResult> AddUser([FromBody] Add_EditDTO userDto)
        //{
        //    if (userDto == null)
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    var createdUser = await _User.AddAsync(userDto);
        //    return Ok(new { Message = "User added successfully.", User = createdUser });
        //}




        ////working

        //[HttpPut]
        //[Route("Updatestudents")]
        //public async Task<IActionResult> UpdateUser([FromBody] Add_EditDTO userDto)
        //{
        //    if (userDto == null || string.IsNullOrEmpty(userDto.Id))
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    var updatedUser = await _User.UpdateAsync(userDto);
        //    return Ok(new { Message = "User updated successfully.", User = updatedUser });
        //}








    }
}
