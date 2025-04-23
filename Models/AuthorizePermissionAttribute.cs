using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;

public class AuthorizePermissionAttribute : Attribute, IAuthorizationRequirement
{
    public string Permission { get; }

    public AuthorizePermissionAttribute(string permission)
    {
        Permission = permission;
    }
}
