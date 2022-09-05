using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M0b3System.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using M0b3System.Dto.Model;
using M0b3System.Entity.Enum;

namespace M0b3System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ContextController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLogin model)
        {
            var result = await _accountService.PasswordSignInAsync(model.UserName, model.Password);

            switch (result)
            {
                case SignInStatus.Success:
                    break;
                case SignInStatus.Failure:
                    break;
            }

            return new JsonResult(Success());
        }
    }
}
