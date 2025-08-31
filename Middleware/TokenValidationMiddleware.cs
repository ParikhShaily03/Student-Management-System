using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Student_Management_System.Data;
using Student_Management_System.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Replace("Bearer ", "");

                // Check if token exists in the revoked tokens table
                var isTokenRevoked = await dbContext.RevokedTokens.AnyAsync(t => t.Token == token);

                if (isTokenRevoked)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token has been revoked. Please log in again.");
                    return;
                }
            }

            await _next(context);
        }

        }
}
