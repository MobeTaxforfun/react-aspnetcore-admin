using RookieAdmin.Models.Entity;
using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Interface.System;

namespace RookieAdmin.Service.Implement.System
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        public async Task<List<SysMenu>> ListedMenu()
        {
            return await _menuRepository.ToListAsync();
        }


    }
}
