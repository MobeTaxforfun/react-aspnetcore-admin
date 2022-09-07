using Microsoft.AspNetCore.Authorization;

namespace M0b3System.API.Common.Auth
{
    public class PermissionsAuthorizationRequirement : IAuthorizationRequirement
    {
        public PermissionsAuthorizationRequirement(string name)
        {
             Name = name ?? throw new ArgumentNullException(nameof(name) + "未指定授權碼");
        }

        public string Name { get; set; }
    }
}
