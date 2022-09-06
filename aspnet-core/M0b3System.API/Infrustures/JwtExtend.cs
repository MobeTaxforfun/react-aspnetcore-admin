using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace M0b3System.API.Infrustures
{
    public class JwtExtend
    {
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
    }
}
