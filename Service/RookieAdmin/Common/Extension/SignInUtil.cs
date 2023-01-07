using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RookieAdmin.Models.Model.Account;
using System.ComponentModel;
using System.Security.Claims;

namespace RookieAdmin.Common.Extension
{
    public static class SignInUtil
    {
        /// <summary>
        /// 登入精靈 (限定 Model)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static async Task DespathSignInAsync(this HttpContext context, SignInContextModel model)
        {
            await DespathSignInAsync(context, model);
        }

        /// <summary>
        /// 登入精靈 (通用)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task DespathSignInAsync(this HttpContext context, object model)
        {
            var descriptors = TypeDescriptor.GetProperties(model);
            var claims = new List<Claim>();

            foreach (PropertyDescriptor descriptor in descriptors)
            {
                var obItem = ObjectUtil.GetPropValue(model, descriptor.Name);
                if (obItem is not null)
                {
                    claims.Add(new Claim($"{Startup.SystemName}" + descriptor.Name, obItem.ToString() ?? "none"));
                }
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
