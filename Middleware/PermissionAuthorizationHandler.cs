using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Student_Management_System.Model;
using Student_Management_System.Repositories.Irepositories;

namespace Student_Management_System.Middleware
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly UserManager<User> _userManager;

        public PermissionAuthorizationHandler(
            IPermissionRepository permissionRepository,
            UserManager<User> userManager)
        {
            _permissionRepository = permissionRepository;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }

            // Get all permissions for the user
            var userId = _userManager.GetUserId(context.User);
            var userPermissions = await _permissionRepository.GetUserPermissionsAsync(userId);

            // Check if the user has the required permission
            if (userPermissions.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }
        }
    }

    // Authorization/PermissionRequirement.cs
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }

    // Authorization/PermissionPolicyProvider.cs
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith("Permission", StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(policy.Build());
            }

            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
