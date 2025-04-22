using Microsoft.AspNetCore.Authorization;
using Student_Management_System.Models;

namespace Student_Management_System.Middleware
{
    public class PermissionHandler : AuthorizationHandler<AuthorizePermissionAttribute>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizePermissionAttribute requirement)
        {
            var userPermissions = _httpContextAccessor.HttpContext.Items["UserPermissions"] as List<Permission>;
            if (userPermissions != null && userPermissions.Any(p => p.Name == requirement.Permission))
            {
                context.Succeed(requirement);  // Permission granted
            }
            else
            {
                context.Fail(); // Permission denied
            }

            return Task.CompletedTask;
        }
    }

}
