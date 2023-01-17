using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Common.Authorizes
{
    /// <summary>
    /// Permission 驗證，更多請參考 .NET Core Github 官方開源的驗證原始碼
    /// </summary>
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(params string[] codes) : base(typeof(PermissionFilter))
        {
            //建構函數 當實例 ActionFilterAttribute 類型沒有在DI容器中註冊，會嘗試從 Arguments 中取得
            Arguments = new[] { new PermissionRequirement(codes) };
        }
    }

    /// <summary>
    /// AuthorizationRequirement 這個介面不用實作任何內容
    /// 單純是為了儲存使用者的驗證訊息而存在
    /// 可以包含 重新導向資訊、驗證類型等等
    /// 這邊 因為使用者資料整合進 HttpContext 了，所以訊息較少
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string ForbiddenPath { get; set; } = string.Empty;

        public string[] Codes { get; private set; }

        public PermissionRequirement(params string[] codes)
        {
            Codes = codes;
        }
    }

    /// <summary>
    /// 真正驗證使用者的地方
    /// 自定義授權 Handler 實作 AuthorizationHandler + 自己定義的 Requirement
    /// AuthorizationHandlerContext 為驗證實的 HttpContext 上下文
    /// Requirement 加上自己建置的見證介面
    /// 因為是上下文可以藉由不同的 Requirement 在驗證時可以呼叫一連串的 Handler
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var role = context.User.Claims.FirstOrDefault(c => c.Type == $"RoleId");
            if (role == null)
            {
                context.Fail();
            }

            //這邊驗證 PermissionCode
            context.Succeed(requirement);
        }
    }

    /// <summary>
    /// 真正實作 Filter 的地方
    /// </summary>
    public class PermissionFilter : System.Attribute, IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly PermissionRequirement _requirement;

        public PermissionFilter(
            IAuthorizationService authorizationService,
            PermissionRequirement requirement)
        {
            _authorizationService = authorizationService;
            _requirement = requirement;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var result = await _authorizationService.AuthorizeAsync(context.HttpContext.User, null, _requirement);
            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
