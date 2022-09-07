using M0b3System.API.Common.Instance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace M0b3System.API.Common.Auth
{
    public class JwtExtend
    {
        /// <summary>
        /// 創建 JWT Token
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="JwtKey"></param>
        /// <param name="Issuer"></param>
        /// <param name="Audience"></param>
        /// <param name="Expiration"></param>
        /// <param name="AdditionalClaims"></param>
        /// <returns></returns>
        public static JwtSecurityToken GetJwtToken(
            string Account,
            string JwtKey,
            string Issuer,
            string Audience,
            int Expiration,
            Claim[] AdditionalClaims = null)
        {
            var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub,Account),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())};

            if (AdditionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(AdditionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                   issuer: Issuer,
                   audience: Audience,
                   notBefore: DateTime.Now,
                   expires: DateTime.Now.AddSeconds(Expiration),
                   claims: claims,
                   signingCredentials: creds);
        }

        /// <summary>
        /// JWT 認證時自動帶入使用者資訊上下文
        /// </summary>
        /// <returns></returns>
        public static Func<TokenValidatedContext, Task> CusJwtOnTokenValidated()
        {
            return context =>
            {
                var aspNetUser = context.HttpContext.RequestServices.GetService<IAspNetUser>();
                var claims = context.Principal.Claims;

                aspNetUser.UserId = 1;

                return Task.CompletedTask;
            };
        }
    }
}
