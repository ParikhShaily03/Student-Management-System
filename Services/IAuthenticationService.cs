using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using Student_Management_System.Models;
using RegisterRequest = Student_Management_System.Models.RegisterRequest;

//using Microsoft.AspNetCore.Identity.Data;
//using Student_Management_System.Data;

namespace Student_Management_System.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequest request);  // Ensure Register method is present
        Task<string> Login(LoginRequest request);        // Add the missing Login method
        //Task<object?> Register(Microsoft.AspNetCore.Identity.Data.RegisterRequest request);
    }
}
