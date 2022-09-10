using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M0b3System.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using M0b3System.Entity.Enum;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using M0b3System.Infrastructure.Common;
using System.IdentityModel.Tokens.Jwt;
using M0b3System.API.Common.Auth;
using M0b3System.Dto.Dto;

namespace M0b3System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ContextController
    {
        private readonly IAccountService _accountService;
        private readonly JwtSecret _jwtSecret;

        public AccountController(IAccountService accountService, IOptions<JwtSecret> jwtSecret)
        {
            _accountService = accountService;
            _jwtSecret = jwtSecret.Value;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLogin model)
        {
            var (singInSttatus, userContext) = await _accountService.PasswordSignInAsync(model.UserName, model.Password);
            string ErrorMsg = "未知錯誤";

            switch (singInSttatus)
            {
                case SignInStatus.Success:

                    var claims = new List<Claim>();
                    claims.Add(new Claim("Account", userContext.Account));
                    claims.Add(new Claim("UserName", userContext.UserName));
                    claims.Add(new Claim("Email", userContext.Email));
                    claims.Add(new Claim("Identy", userContext.Id.ToString()));

                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim(ClaimTypes.Role, "Normal"));

                    claims.Add(new Claim("Permissions", "M0b3.User.Create"));
                    claims.Add(new Claim("Permissions", "M0b3.User.Update"));
                    claims.Add(new Claim("Permissions", "M0b3.User.Delete"));

                    var token = JwtExtend.GetJwtToken(
                        Account: userContext.Account,
                        JwtKey: _jwtSecret.Key,
                        Issuer: _jwtSecret.Issuer,
                        Audience: _jwtSecret.Audience,
                        Expiration: 600,
                        AdditionalClaims: claims.ToArray()
                        );

                    return new JsonResult(Success(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    }));

                case SignInStatus.Failure:
                    break;
                case SignInStatus.LockedOut:
                    break;
            }

            return new JsonResult(Failed(ErrorMsg));
        }
    }
}
