using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Data;
using Student_Management_System.Model;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System.Enums;

namespace Student_Management_System.Middleware
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;


        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,
                                 UserManager<User> userManager,
                               
                                 ApplicationDbContext dbContext)
        {
            var user = context.User;
            

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
               
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                Console.WriteLine("User ID: " + userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    var userEntity = await userManager.FindByIdAsync(userId);
                    var userRoles = await userManager.GetRolesAsync(userEntity);

                    var rolePermissions = await (from role in dbContext.Roles
                                                 join rolePermission in dbContext.RolePermissions on role.Id equals rolePermission.RoleId
                                                 join permission in dbContext.Permissions on rolePermission.PermissionId equals permission.Id
                                                 where userRoles.Contains(role.Name)
                                                 select permission.Name).Distinct().ToListAsync();

                    // Save the permissions in HttpContext for later use
                    context.Items["UserPermissions"] = rolePermissions;
                    Console.WriteLine("Permissions: " + string.Join(", ", rolePermissions));

                    context.Items["UserPermissions"] = rolePermissions;

                }
            }

            await _next(context);
        }
    }

    public class HasPermissionAttribute : Attribute, IAuthorizationFilter
    {
        public string PermissionName { get; }

        public HasPermissionAttribute(PermissionEnum permissionEnum)
        {
            PermissionName = permissionEnum.ToString(); // Convert enum to string
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try 
            {
                if (context.HttpContext.Items.TryGetValue("UserPermissions", out var permissionsObj)
                    && permissionsObj is List<string> userPermissions)
                {
                    if (!userPermissions.Contains(PermissionName))
                    {
                        context.Result = new ForbidResult(); // No permission
                    }
                }
                else
                {
                    context.Result = new UnauthorizedResult(); // Permissions not available
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Authorization error: {ex.Message}");
            }
        }
    }

    //public class PermissionRequirementFilter : IAuthorizationFilter
    //{
    //    private readonly string _permission;

    //    public PermissionRequirementFilter(string permission)

    //    {
    //        _permission = permission;
    //        Console.WriteLine("Checking for permission: " + _permission);
    //        if (permission == null)
    //        {
    //            Console.WriteLine("UserPermissions is NULL");
    //        }
    //        else
    //        {
    //            Console.WriteLine("UserPermissions from context: " + string.Join(", ", permission));
    //        }
    //    }

    //    public class HasPermissionAttribute : Attribute
    //    {
    //        public string PermissionName { get; }

    //        public HasPermissionAttribute(string permissionName)
    //        {
    //            PermissionName = permissionName;
    //        }


    //    }


    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        try
    //        {
    //            if (context.HttpContext.Items.TryGetValue("UserPermissions", out var permissionsObj)
    //                && permissionsObj is List<string> userPermissions)
    //            {
    //                if (!userPermissions.Contains(_permission))
    //                {
    //                    context.Result = new ForbidResult(); // No permission
    //                }
    //            }
    //            else
    //            {
    //                context.Result = new UnauthorizedResult(); // Permissions not available
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Authorization error: {ex.Message}");
    //           // context.Result = new UnauthorizedResult(); // Optional fallback
    //        }
    //    }
    //}

}
