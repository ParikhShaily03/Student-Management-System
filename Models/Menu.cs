using Microsoft.AspNetCore.Identity;
using Student_Management_System.Enums;
using Student_Management_System.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Menu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public int? ParentId { get; set; }
    //  public string Role { get; set; }
    public bool IsActive { get; set; }
    public int SortOrder { get; set; }
    public bool IsSubMenu { get; set; }
    public bool IsExternal { get; set; }
    public string Target { get; set; }
    public string CssClass { get; set; }
    [JsonIgnore]
    public ICollection<MenuRole> MenuRoles { get; set; } = new List<MenuRole>();

}
public class MenuRole
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Menu")]

    public int MenuId { get; set; }          // Explicit FK

    [JsonIgnore]
    public Menu Menu { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public ApplicationRole Role { get; set; }

    //public int Permissions { get; set; } = 0;  // store combined PermissionEnum flags
}


public class MenuDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public int? ParentId { get; set; }
    public bool IsActive { get; set; }
    public bool IsSubMenu { get; set; }
    public bool IsExternal { get; set; }
    public string Target { get; set; }
    public string CssClass { get; set; }

    //  public List<string> RoleIds { get; set; } = new();
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

    public List<string> AssignedRoleIds { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

    public List<string> AssignedRoleNames { get; set; } = new();


}

public class RolePermissionAssignment
{
    public string RoleId { get; set; }
    public List<PermissionEnum> Permissions { get; set; } = new();
}



    public class MenuRoleDto
    {
        public int MenuId { get; set; }
        public List<RolePermissionAssignment> RolePermissions { get; set; } = new();
    }


public class UserMenuPermissionDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }  // or email/display name
    public int MenuId { get; set; }
    public string MenuTitle { get; set; }
    public int Permissions { get; set; }  // combined permissions flags
}

public class MenuRolePermission
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Menu")]
    public int MenuId { get; set; }
    public Menu Menu { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public ApplicationRole Role { get; set; }

   public PermissionEnum Permission { get; set; }
}

public class RemoveRolePermissionsDto
{
    public int MenuId { get; set; }
    public string RoleId { get; set; }
    public List<PermissionEnum> PermissionsToRemove { get; set; } = new();
}
