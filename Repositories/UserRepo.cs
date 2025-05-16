using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;
using Student_Management_System.Repositories.Irepositories;


namespace Student_Management_System.Repositories
{
    public class UserRepo<T> : IUser<T> where T : class
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public UserRepo(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _dbSet = context.Set<T>();
        }



        public async Task<PagedResult<T>> GetPagedAsync(PaginationParameters paginationParameters)
        {
            var totalCount = await _dbSet.CountAsync();

            var items = await _dbSet
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<Add_EditDTO> AddAsync(Add_EditDTO userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,  // Assuming username is email
                Email = userDto.Email,
                Name = userDto.Name,
                Department = userDto.Department,


            };

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(ApiMessage.Notcreated);
            }
            return new Add_EditDTO
            {
                Name = user.UserName,
                Email = user.Email
            };

        }



        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(ApiMessage.BadRequest);

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new Exception(ApiMessage.NotFound);

            user.IsDeleted = true; // Soft delete

            var result = await _userManager.UpdateAsync(user);




            //    var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }



        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _userManager.Users.Where(u => !u.IsDeleted)
                .Select(user => new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Department = user.Department,
                })
                .ToListAsync(); // Ensures it returns Task<IEnumerable<UserDTO>>
        }

        //public Task GetAllUsersAsync()
        //{
        //     var users = _userManager.Users.FirstOrDefaultAsync();
        //     return users;
        //}

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {

                return null; // Or throw an exception based on your error handling approach
            }

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                Department = user.Department,
            };
        }


        public async Task<Add_EditDTO> UpdateAsync(Add_EditDTO userDto)
        {

            if (userDto == null || string.IsNullOrEmpty(userDto.Id))
                throw new ArgumentNullException("UserDTO or ID cannot be null.");

            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user == null)
                throw new Exception("User not found.");

            // Update user properties
            user.Name = userDto.Name;
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("User update failed.");
            }

            // Return updated user as DTO
            return new Add_EditDTO
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email
            };
        }
        public async Task<Add_EditDTO> UpsertUserAsyc(Add_EditDTO userDto, Guid? ID)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            User user;

            if (!string.IsNullOrEmpty(userDto.Id) || ID.HasValue)

            {

                string userId = ID.HasValue ? ID.Value.ToString() : userDto.Id;
                // **UPDATE User**
                user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new Exception(ApiMessage.NotFound);

                // Update user properties
                user.Name = userDto.Name;
                user.UserName = userDto.UserName;
                user.Email = userDto.Email;
                user.Department = userDto.Department;

                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                    throw new Exception(ApiMessage.NotUpdated);
            }
            else
            {
                // **ADD New User**
                user = new User
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    Name = userDto.Name,
                    Department = userDto.Department,
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                    throw new Exception(ApiMessage.Notcreated);
            }

            // Return updated/created user details
            return new Add_EditDTO
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Department = user.Department,
            };

        }



    }
}
