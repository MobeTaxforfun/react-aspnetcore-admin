using M0b3System.Dto.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M0b3System.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BasicApiController
    {
        public MenuController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            return new JsonResult(Success());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMenu(long Id)
        {
            return new JsonResult(Success());
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(MenuModel model)
        {
            return new JsonResult(Success());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMenu(long Id, MenuModel model)
        {
            return new JsonResult(Success());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMenu(long Id)
        {
            return new JsonResult(Success());
        }

    }
}
