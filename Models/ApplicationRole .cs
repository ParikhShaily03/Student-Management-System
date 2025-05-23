using Microsoft.AspNetCore.Identity;
using Student_Management_System.Models;
using System;

public class ApplicationRole : IdentityRole
{
    

    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; }

}
