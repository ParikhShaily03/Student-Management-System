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
        [HasPermission(PermissionEnum.ViewUsers)]

        //[HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationParameters paginationParameters, [FromQuery] string search = "")
        {
            try
            {

                if (paginationParameters == null)
                {
                    return BadRequest(new { Message = "Pagination parameters are required." });
                }

                if (paginationParameters.PageNumber < 1) paginationParameters.PageNumber = 1;
                if (paginationParameters.PageSize < 1) paginationParameters.PageSize = 10;

                var query = applicationDbContext.Users.Where(u => !u.IsDeleted).AsQueryable();

                // 🔍 Apply search filter BEFORE pagination
                if (!string.IsNullOrEmpty(search))
                {
                    search = search.ToLower();
                    query = query.Where(u =>
                        u.Name.ToLower().Contains(search) ||
                        u.Email.ToLower().Contains(search) ||
                        u.Department.ToLower().Contains(search) ||
                        u.UserName.ToLower().Contains(search)
                    );
                }

                // ✅ Get total count BEFORE pagination
                int totalCount = await query.CountAsync();
                Console.WriteLine($"Total users after filtering: {totalCount}");


                if (!string.IsNullOrEmpty(paginationParameters.SortField))
                {
                    switch (paginationParameters.SortField.ToLower())
                    {
                        case "name":
                            query = paginationParameters.SortOrder?.ToLower() == "desc"
                                ? query.OrderByDescending(u => u.Name)
                                : query.OrderBy(u => u.Name);
                            break;
                        case "email":
                            query = paginationParameters.SortOrder?.ToLower() == "desc"
                                ? query.OrderByDescending(u => u.Email)
                                : query.OrderBy(u => u.Email);
                            break;
                        default:
                            // No sorting if field is not recognized
                            break;
                    }
                }
                // ✅ Apply pagination AFTER filtering
                var users = await query
                    //.OrderBy(u => u.UserName) // Sorting
                    .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                    .Take(paginationParameters.PageSize)
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        u.Department,
                        u.UserName
                    })
                .ToListAsync();



                // ✅ Return correct pagination + search results
                return Ok(new
                {
                    Message = ApiMessage.Success,
                    Data = users,
                    TotalCount = totalCount, // Should be BEFORE pagination
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

        //[Route("UpsertUser/{id?}")]
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
