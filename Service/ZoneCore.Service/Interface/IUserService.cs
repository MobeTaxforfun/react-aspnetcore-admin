using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Models.Dto;
using ZoneCore.Models.Model;

namespace ZoneCore.Service.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// 使用者分頁查詢
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<List<UserDto>> PaginateUser(UseSearchParameter model);

        /// <summary>
        /// 創建使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<int> CreateUser(UserDto model);

        /// <summary>
        /// 更新使用者資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<int> UpdateUser(UserDto model);

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<int> DeleteUser(int Id);

        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<UserDto> GetUser(int Id);

        /// <summary>
        /// 修改使用者狀態
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Task<int> SetUserState(UserDto model);

        /// <summary>
        /// 設定使用者角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public Task<int> SetUserRole(int UserId, List<int> RoleId);
        public void ListedUser();
    }
}
