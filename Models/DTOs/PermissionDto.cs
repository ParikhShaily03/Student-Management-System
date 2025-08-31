using Student_Management_System.Models.DTOs;

namespace Student_Management_System.Models.DTOs
{
    // DTOs/PermissionDto.cs
    public class PermissionDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    // DTOs/RolePermissionDto.cs
    public class RolePermissionDto
    {
        public List<string> RoleIds { get; set; }
        public string PermissionId { get; set; }
    }

    // DTOs/UserPermissionsDto.cs
    public class RolePermissionsDto
    {
        public string RoleId { get; set; }
        public List<string> Permissions { get; set; }
    }
}
