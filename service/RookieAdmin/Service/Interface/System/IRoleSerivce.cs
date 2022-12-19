using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Models.Model;

namespace RookieAdmin.Service.Interface.System
{
    public interface IRoleSerivce
    {
        /// <summary>
        /// 建立角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<int> CreateRole(SysRoleDto dto);
        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<int> DeleteRole(int Id);
        /// <summary>
        /// 列出角色
        /// </summary>
        /// <returns></returns>
        public Task<List<SysRole>> ListedRole();
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<int> UpdateRole(SysRoleDto dto);

        /// <summary>
        /// 角色列表分頁(尚未實作)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<PagedModel<SysRole>> PaginateRole(RoleSearchModel model);
    }
}
