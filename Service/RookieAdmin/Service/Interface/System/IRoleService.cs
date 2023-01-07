using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Models.Model;

namespace RookieAdmin.Service.Interface.System
{
    public interface IRoleService
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
        public Task<PagedModel<SysRoleDto>> PaginateRole(RoleSearchModel model);

        /// <summary>
        /// 列出角色(僅 Id 與 Name)
        /// </summary>
        /// <returns></returns>
        public Task<List<SysRoleIdAndNameDto>> ListedRoleIdAndName();

        /// <summary>
        /// 變更角色狀態
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Task<int> SetRoleStatus(int Id, int Status);
    }
}
