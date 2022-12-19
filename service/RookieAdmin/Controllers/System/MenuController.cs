using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Service.Interface.System;
using RookieAdmin.ViewModels.System;

namespace RookieAdmin.Controllers.System
{
    public class MenuController : BaseAuthController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        [HttpGet("Lised")]
        public async Task<IActionResult> ListedMenu(MenuSearchModel model)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuVM model)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(UpdateMenuVM model)
        {
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMenu(int Id)
        {
            return Ok();
        }
    }
}
