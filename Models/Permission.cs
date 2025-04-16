using AutoMapper;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Models

{
    public class Permission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } // e.g., "User.Create"
        public string Description { get; set; }
        public string Category { get; set; } // e.g., "UserManagement"
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class RolePermission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }
        public string PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

}
