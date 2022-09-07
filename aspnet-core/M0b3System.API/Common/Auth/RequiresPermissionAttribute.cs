using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace M0b3System.API.Common.Auth
{
    public class RequiresPermissionAttribute : TypeFilterAttribute
    {
        public RequiresPermissionAttribute(params string[] codes) : base(typeof(PermissionsAsyncResourceFilter))
        {
            Arguments = new[] { new PermissionsAuthorizationRequirement(codes[0]) };
        }

        private class PermissionsAsyncResourceFilter : Attribute, IAsyncResourceFilter
        {
            private readonly IAuthorizationService _authService;
            private readonly PermissionsAuthorizationRequirement _permissionRequirement;

            public PermissionsAsyncResourceFilter(
                IAuthorizationService authService,
                PermissionsAuthorizationRequirement permissionRequirement)
            {

                _authService = authService;
                _permissionRequirement = permissionRequirement;
            }


            public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
            {
                var result = await _authService.AuthorizeAsync(context.HttpContext.User,
                                       context.ActionDescriptor.ToString(),
                                       _permissionRequirement);
                if (!result.Succeeded)
                {
                    //無授權
                    context.Result = new ChallengeResult();
                }
                else
                {
                    //通過授權前往下一個 pip
                    await next();
                }
            }
        }
    }
}
