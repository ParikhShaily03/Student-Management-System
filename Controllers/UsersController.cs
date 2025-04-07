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

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    //[Authorize]
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
                    Message = ApiMassage.Success,
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


            //    try
            //    {
            //        var query = applicationDbContext.Users.
            //
            //
            //        ();

            //        if (!string.IsNullOrEmpty(search))
            //        {
            //            query = query.Where(u =>
            //            u.Name.ToLower().Contains(search.ToLower()) ||
            //            u.Email.ToLower().Contains(search.ToLower()) ||
            //            u.Department.ToLower().Contains(search.ToLower()) ||
            //            u.UserName.ToLower().Contains(search.ToLower())
            //);
            //        }

            //        int totalCount = await query.CountAsync();
            //        Console.WriteLine($"Total users after filtering: {totalCount}");

            //        var Users = await _User.GetAllAsync();
            //        if (paginationParameters == null)
            //        {
            //            return BadRequest(new { Message = "Pagination parameters are required." });
            //        }

            //        if (paginationParameters.PageNumber < 1) paginationParameters.PageNumber = 1;
            //        if (paginationParameters.PageSize < 1) paginationParameters.PageSize = 10;




            //        Console.WriteLine($"Total users after filtering: {query.Count()}");
            //        // Count before pagination

            //        var users = await query
            //            .OrderBy(u => u.UserName)
            //            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            //            .Take(paginationParameters.PageSize)
            //            .Select(u => new
            //            {
            //                u.Id,
            //                u.Name,
            //                u.Email,
            //                u.Department,
            //                u.UserName
            //            })
            //            .ToListAsync();




            //        //var totalUsers = await applicationDbContext.Users.CountAsync();



            //        //return Ok(Users);
            //        return Ok(new { Message = ApiMassage.Success, data = users, TotalCount = query.Count() });
            //    }
            //    catch (Exception ex)
            //    {
            //        return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });

            //    }

            //    }

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
            return Ok( user );


        }

        //[Authorize]
        [HttpPost("UpsertUser")]

        //[Route("UpsertUser/{id?}")]
        public async Task<IActionResult> UpsertUser([FromBody] Add_EditDTO userDto, [FromQuery] Guid? ID)
        {
            if (userDto == null)
                return Ok(ApiMassage.BadRequest);

            try
            {
                var result = await _User.UpsertUserAsyc(userDto, ID);
                return Ok(new { Message = ApiMassage.Updated, User = result });
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
                return Ok(ApiMassage.BadRequest);
            }

            var isDeleted = await _User.DeleteAsync(id);
            if (!isDeleted)
            {
                return Ok(ApiMassage.InternalServerError);
            }

            return Ok(new { Message = "User soft deleted successfully." });
        }


        //[HttpGet]
        //public IActionResult GetUsers([FromQuery] PaginationParameters paginationParameters, [FromQuery] string search = "")
        //{
        //    var query = applicationDbContext.Users.AsQueryable();

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        query = query.Where(u =>
        //            u.Name.Contains(search) ||
        //            u.Email.Contains(search) ||
        //            u.Department.Contains(search) ||
        //            u.UserName.Contains(search)
        //        );
        //    }

        //    // Perform search query in your database
        //    var totalCount = query.Count(); // Count before pagination

        //    var users = query
        //        .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
        //        .Take(paginationParameters.PageSize)
        //        .Select(u => new
        //        {
        //            u.Id,
        //            u.Name,
        //            u.Email,
        //            u.Department,
        //            u.UserName
        //        })
        //        .ToList();


        //    return Ok(new
        //    {
        //        totalCount = totalCount,
        //        data = users
        //    });
        //}
    }
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









