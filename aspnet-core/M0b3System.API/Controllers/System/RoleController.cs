using M0b3System.Dto.Dto;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BasicApiController
    {
        public RoleController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return new JsonResult(Success());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRole(long Id)
        {
            return new JsonResult(Success());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            return new JsonResult(Success());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateRole(long Id, RoleModel model)
        {
            return new JsonResult(Success());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRole(long Id)
        {
            return new JsonResult(Success());
        }
    }
}
