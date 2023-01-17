using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZoneCore.Infra.Extension;
using ZoneCore.Models.Model;

namespace ZoneCore.Common.Instances
{
    public class JwtSecurity
    {
        private readonly IConfiguration _configuration;

        public JwtSecurity(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateToken(SignInContextModel model, int expireMinutes = 30)
        {
            var issuer = _configuration["JwtSettings:Issuer"];
            var signKey = _configuration["JwtSettings:SignKey"];

            // 設定要加入到 JWT Token 中的聲明資訊(Claims)
            var claims = new List<Claim>();
            // 在 RFC 7519 規格中(Section#4)，總共定義了 7 個預設的 Claims，我們應該只用的到兩種！
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, model.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var descriptors = TypeDescriptor.GetProperties(model);
            //這邊會把 SignInContextModel 塞進 Claim 裡面 但 Account 其實重複了
            foreach (PropertyDescriptor descriptor in descriptors)
            {
                var obItem = ObjectUtil.GetPropValue(model, descriptor.Name);
                if (obItem is not null)
                {
                    claims.Add(new Claim($"" + descriptor.Name, obItem.ToString() ?? "none"));
                }
            }

            var userClaimsIdentity = new ClaimsIdentity(claims);
            // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            // HmacSha256 有要求必須要大於 128 bits，所以 key 不能太短，至少要 16 字元以上
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Subject = userClaimsIdentity,
                Expires = DateTime.Now.AddMinutes(expireMinutes),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return serializeToken;
        }
    }
}
