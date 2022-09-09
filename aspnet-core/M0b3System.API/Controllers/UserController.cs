using M0b3System.API.Common.Auth;
using M0b3System.API.Common.Instance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BasicApiController
    {
        private readonly IAspNetUser _aspNetUser;

        public UserController(IAspNetUser aspNetUser)
        {
            _aspNetUser = aspNetUser;
        }

        [HttpGet]
        [RequiresPermission("test")]
        public async Task<IActionResult> GetUser()
        {
            var test = _aspNetUser.UserId;
            return new JsonResult(Success());
        }

        public async Task<IActionResult> GetUser(long Id)
        {
            return new JsonResult(Success());
        }
    }
}
