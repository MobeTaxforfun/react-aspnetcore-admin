using Microsoft.AspNetCore.Mvc;
using ZoneCore.Models.Dto;
using ZoneCore.Models.Model;
using ZoneCore.Repository.Interface;
using ZoneCore.Service.Interface;
using ZoneCore.Web.Controllers.Basic;
using ZoneCore.Web.ViewModels;

namespace ZoneCore.Web.Controllers.System
{
    [Route("System/User")]
    public class SysUserController : BaseAuthController
    {
        private readonly IUserService _userService;
        private readonly ISysUserRepository _sysUserRepository;

        public SysUserController(
            IUserService userService,
            ISysUserRepository sysUserRepository
            )
        {
            this._userService = userService;
            this._sysUserRepository = sysUserRepository;
        }

        /// <summary>
        /// 分頁取得使用者列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("Paginate")]
        public IActionResult PaginateUser(UseSearchParameter model)
        {
            return Successful();
        }

        /// <summary>
        /// 根據ID取得使用者訊息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetUser(int Id)
        {
            var users = _sysUserRepository.Select(c => c.Enable == 1);
            return Successful();
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(UserDto model)
        {
            _userService.CreateUser(model);
            return Successful();
        }

        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateUser(UserDto model)
        {
            return Successful();
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            return Successful();
        }

        /// <summary>
        /// 修改使用者狀態
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("SetStatus")]
        public IActionResult UpdateUserStatus(UserDto model)
        {
            return Successful();
        }

        /// <summary>
        /// 取得這個使用者現在的角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("UserRole/{Id}")]
        public IActionResult GetUserAuthRole(int Id)
        {
            _userService.ListedUser();
            return Successful();
        }

        /// <summary>
        /// 設定使用者角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UserRole")]
        public IActionResult UpdateUserRole(UpdateUserRoleVM model)
        {
            return Successful();
        }

        /// <summary>
        /// 取得這個登入使用者的相關資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("Info")]
        public IActionResult GetUserInfo()
        {
            return Successful();
        }

        /// <summary>
        /// 取得這個登入使用者相關權限路由路徑
        /// </summary>
        /// <returns></returns>
        [HttpGet("Routers")]
        public IActionResult GetRouter()
        {
            return Successful();
        }
    }
}
