using Microsoft.AspNetCore.Identity;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Management_System.Repositories.Irepositories
{
    public interface IUser<T> where T : class
    {
        Task<PagedResult<T>> GetPagedAsync(PaginationParameters paginationParameters);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<Add_EditDTO> AddAsync(Add_EditDTO userDto);


        Task<Add_EditDTO> UpdateAsync(Add_EditDTO userDto);

        Task<bool> DeleteAsync(string id);

        Task<bool> CheckPasswordAsync(User user, string password);

        Task<Add_EditDTO> UpsertUserAsyc(Add_EditDTO userDto, Guid ? ID);

        Task<IEnumerable<UserDTO>> GetChatContactsAsync(string currentUserId);


    }
}
