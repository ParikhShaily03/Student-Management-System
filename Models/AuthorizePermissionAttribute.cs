using Microsoft.AspNetCore.Authorization;

namespace Student_Management_System.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizePermissionAttribute : Attribute, IAuthorizationRequirement
    {
        public PermissionType Permission { get; }

        public AuthorizePermissionAttribute(PermissionType permission)
        {
            Permission = permission;
        }
    }
}
