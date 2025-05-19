using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

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
}


public class MenuDto
{
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

}

public class MenuRoleDto
{
    public int MenuId { get; set; }
    public List<string> RoleIds { get; set; }
}