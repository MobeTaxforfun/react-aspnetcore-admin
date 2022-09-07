using Microsoft.AspNetCore.Authorization;

namespace M0b3System.API.Common.Auth
{
    public class PermissionsAuthorizationHandler : AuthorizationHandler<PermissionsAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsAuthorizationRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
