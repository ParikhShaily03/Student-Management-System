using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Enums;
using Student_Management_System.Model;
using Student_Management_System.Models;
using System.Security.Claims;

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
                    var menuPermissions = await (from role in dbContext.Roles
                                                 join mr in dbContext.MenuRolePermissions on role.Id equals mr.RoleId
                                                 where userRoles.Contains(role.Name)
                                                 select new
                                                 {
                                                     mr.MenuId,
                                                     mr.Permission
                                                 }).ToListAsync();

                    var permissionDict = new Dictionary<int, PermissionEnum>();
                    foreach (var mp in menuPermissions)
                    {
                        if (permissionDict.TryGetValue(mp.MenuId, out var existing))
                        {
                            permissionDict[mp.MenuId] = existing | (PermissionEnum)mp.Permission;
                        }
                        else
                        {
                            permissionDict[mp.MenuId] = (PermissionEnum)mp.Permission;
                        }
                    }

                    context.Items["UserMenuPermissions"] = permissionDict;
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

    public class HasMenuPermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _menuUrl;
        private readonly PermissionEnum _permission;

        public HasMenuPermissionAttribute(string menuUrl, PermissionEnum permission)
        {
            _menuUrl = menuUrl;
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            var menu = db.Menus.FirstOrDefault(m => m.Url == _menuUrl);

            if (menu == null ||
                !context.HttpContext.Items.TryGetValue("UserMenuPermissions", out var value) ||
                value is not Dictionary<int, PermissionEnum> menuPermissions ||
                !menuPermissions.TryGetValue(menu.Id, out var perms) ||
                !perms.HasFlag(_permission))
            {
                context.Result = new ForbidResult();
            }
        }
    }


}