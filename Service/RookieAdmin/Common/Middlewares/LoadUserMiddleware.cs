using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using RookieAdmin.Common.AppAuthorize;
using RookieAdmin.Common.Instances;

namespace RookieAdmin.Common.Middlewares
{
    /// <summary>
    /// 用於自動載入登入使用者的資訊 放置於驗證之後
    /// </summary>
    public class LoadUserMiddleware
    {
        private readonly IAspNetUser _aspNetUser;
        private readonly RequestDelegate _next;

        public LoadUserMiddleware(
            IAspNetUser aspNetUser,
            RequestDelegate next)
        {
            this._aspNetUser = aspNetUser ?? throw new ArgumentNullException(nameof(aspNetUser));
            this._next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //有認證
            if (httpContext.User.Identity?.IsAuthenticated == true)
            {
                _aspNetUser.LoadUserInfo();

                var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                var PermisAttribute = endpoint?.Metadata.GetMetadata<PermissionAttribute>();
            }

            await _next(httpContext);
        }
    }
}
