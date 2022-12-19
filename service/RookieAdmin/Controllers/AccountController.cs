using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Common.AppException;
using RookieAdmin.Common.Instances;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Models.Enum;
using RookieAdmin.Service.Interface;
using RookieAdmin.ViewModels;

namespace RookieAdmin.Controllers
{
    public class AccountController : BasicController
    {
        private readonly JwtSecurity _jwtSecurity;
        private readonly IAccountService _accountService;

        public AccountController(
            JwtSecurity jwtSecurity,
            IAccountService accountService)
        {
            this._jwtSecurity = jwtSecurity;
            this._accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            var signInResult = await _accountService.PasswordSignInAsync(model.UserName, model.Password);

            switch (signInResult.Result)
            {
                case LoginResult.Success:

                    if (signInResult.CurrentUser == null)
                    {
                        throw new BusinessException("帳號登入流程錯誤");
                    }
                    var Token = _jwtSecurity.GenerateToken(signInResult.CurrentUser);
                    return Successful(data: new { Token = Token });

                default:
                    return Failure("登入失敗");
            }

        }

        [HttpGet("Logout")]
        /// <summary>
        /// 登出 JWT其實沒有登出喔 :D
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            return Json(Success("成功登出"));
        }
    }
}
