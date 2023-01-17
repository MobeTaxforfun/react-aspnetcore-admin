using Microsoft.AspNetCore.Mvc;
using ZoneCore.Common.Instances;
using ZoneCore.Infra.Exceptions;
using ZoneCore.Models.Enum;
using ZoneCore.Service.Interface;
using ZoneCore.Web.Controllers.Basic;
using ZoneCore.Web.ViewModels;

namespace ZoneCore.Web.Controllers
{
    /// <summary>
    /// 處理使用者不再認證權限內的時候，使用者相關的業務
    /// </summary>
    public class AccountController : BasicController
    {
        private readonly IAccountService _accountService;
        private readonly JwtSecurity _jwtSecurity;

        public AccountController(
            IAccountService accountService,
            JwtSecurity jwtSecurity)
        {
            this._jwtSecurity = jwtSecurity;
            this._accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM model)
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
    }
}
