using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BasicApiController
    {
        public UserController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return new JsonResult(Success());
        }
    }
}
