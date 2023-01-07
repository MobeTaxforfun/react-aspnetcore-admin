using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Models.Model;
using RookieAdmin.Common.AppException;

namespace RookieAdmin.Service.Interface.System
{
    public interface IUserService
    {
        /// <summary>
        /// 切換使用者狀態
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<int> ChangeStatus(int Id);
        /// <summary>
        /// 創建使用者
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<int> CreateUser(SysUserDto dto);
        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<int> DeleteUser(int Id);
        /// <summary>
        /// 分頁列表現在使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<PagedModel<SysUser>> PaginateUser(UserSearchModel model);
        /// <summary>
        /// 設定使用者權限
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public Task<int> SetRoles(int Id, List<int> RoleIds);
        /// <summary>
        /// 更新使用者資訊
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<int> UpdateUser(SysUserDto dto);
        /// <summary>
        /// 取得使用者 By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<SysUser> GetUser(int Id);
    }
}
