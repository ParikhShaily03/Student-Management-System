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
using Student_Management_System.Models;
using Microsoft.Data.SqlClient;
using Student_Management_System.Middleware;
using static Student_Management_System.Middleware.PermissionMiddleware;
using Student_Management_System.Enums;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {


        private readonly ApplicationDbContext applicationDbContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IUser<User> _User;

        // public StudentController(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;
        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger, IUser<User> User)
        {
            applicationDbContext = context;
            _logger = logger;
            _User = User ?? throw new ArgumentNullException(nameof(User));
        }


        [HttpGet]
        [Route("GetUsers")]
        [HasPermission(PermissionEnum.View)]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationParameters paginationParameters, [FromQuery] string search = "")
        {
            try
            {
                if (paginationParameters == null)
                {
                    return BadRequest(new { Message = "Pagination parameters are required." });
                }

                var query = applicationDbContext.Users.Where(u => !u.IsDeleted).AsQueryable();

                // Use the new PaginationService
                var paginationService = new PaginationService<User>(query);
                var result = await paginationService.ApplyPaginationAsync(paginationParameters, search);

                // Project to DTO if needed
                var users = result.Items.Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Department,
                    u.UserName
                }).ToList();

                return Ok(new
                {
                    Message = ApiMessage.Success,
                    Data = users,
                    TotalCount = result.TotalCount,
                    PageNumber = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    SortBy = paginationParameters.SortField,
                    SortOrder = paginationParameters.SortOrder
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        [HasPermission(PermissionEnum.View)]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _User.GetByIdAsync(id);
            if (user == null)
            {
                return Ok(ApiMessage.NotFound);
            }

            //return Ok(user);
            return Ok(user);


        }

        //[Authorize]
        [HttpPost("UpsertUser")]
        [HasPermission(PermissionEnum.Edit)]
        public async Task<IActionResult> UpsertUser([FromBody] Add_EditDTO userDto, [FromQuery] Guid? ID)
        {
            if (userDto == null)
                return Ok(ApiMessage.BadRequest);

            try
            {
                var result = await _User.UpsertUserAsyc(userDto, ID);
                return Ok(new { Message = ApiMessage.Updated, User = result });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [HasPermission(PermissionEnum.Delete)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Ok(ApiMessage.BadRequest);
            }

            var isDeleted = await _User.DeleteAsync(id);
            if (!isDeleted)
            {
                return Ok(ApiMessage.InternalServerError);
            }

            return Ok(new { Message = "User soft deleted successfully." });
        }
    }
}
