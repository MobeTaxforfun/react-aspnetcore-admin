using M0b3System.Dto.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : BasicApiController
    {
        public PermissionController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return new JsonResult(Success());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPermission(long Id)
        {
            return new JsonResult(Success());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(PermissionModel model)
        {
            return new JsonResult(Success());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePermission(long Id, PermissionModel model)
        {
            return new JsonResult(Success());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePermission(long Id)
        {
            return new JsonResult(Success());
        }
    }
}
