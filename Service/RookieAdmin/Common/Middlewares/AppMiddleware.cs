namespace RookieAdmin.Common.Middlewares
{
    /// <summary>
    /// 註冊自訂 Middleware 的地方
    /// </summary>
    public static class AppMiddleware
    {
        public static IApplicationBuilder UseLoadUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoadUserMiddleware>();
        }
    }
}
