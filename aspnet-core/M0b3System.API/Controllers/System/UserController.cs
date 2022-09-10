using M0b3System.API.Common.Auth;
using M0b3System.API.Common.Instance;
using M0b3System.Dto.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers.System
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
        public async Task<IActionResult> GetUsers()
        {
            var test = _aspNetUser.UserId;
            return new JsonResult(Success());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(long Id)
        {
            return new JsonResult(Success());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            return new JsonResult(Success());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(long Id, UserModel model)
        {
            return new JsonResult(Success());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(long Id)
        {
            return new JsonResult(Success());
        }
    }
}
