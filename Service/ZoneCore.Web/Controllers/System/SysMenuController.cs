using Microsoft.AspNetCore.Mvc;
using ZoneCore.Models.Dto;
using ZoneCore.Web.Controllers.Basic;

namespace ZoneCore.Web.Controllers.System
{
    [Route("System/Menu")]
    public class SysMenuController : BaseAuthController
    {
        /// <summary>
        /// 取得選單列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listed")]
        public IActionResult ListedMenu()
        {
            return Successful();
        }


        [HttpGet("TreeSelect")]
        public IActionResult TreeSelectMenu()
        {
            return Successful();
        }

        [HttpGet("TreeSelect/Role/{Id}")]
        public IActionResult TreeSelectMenuByRoleId(int Id)
        {
            return Successful();
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuDto model)
        {
            return Successful();
        }

        [HttpPut]
        public IActionResult UpdateMenu(MenuDto model)
        {
            return Successful();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteMenu(int Id)
        {
            return Successful();
        }

    }
}
