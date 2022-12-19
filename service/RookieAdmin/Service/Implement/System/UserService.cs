using AutoMapper;
using RookieAdmin.Common.AppException;
using RookieAdmin.Common.Extension.Security;
using RookieAdmin.Common.Instances;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Interface.System;

namespace RookieAdmin.Service.Implement.System
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IAspNetUser _aspNetUser;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        // 用於指定哪個ID 以下不會被異動
        private const int LimitAdminId = 1;

        public UserService(
            IMapper mapper,
            IAspNetUser aspNetUser,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _aspNetUser = aspNetUser;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        /// <summary>
        /// 分頁列表現在使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedModel<SysUser>> PaginateUser(UserSearchModel model)
        {
            var result = await _userRepository.PaginateUser(model);

            return new PagedModel<SysUser>()
            {
                TotalCount = result.TotalCount,
                TableData = result.Data
            };
        }

        /// <summary>
        /// 創建使用者
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> CreateUser(SysUserDto dto)
        {

            if (await _userRepository.ExistAsync(c => c.Account == dto.Account))
            {
                throw new BusinessException("帳號已存在");
            }

            var user = _mapper.Map<SysUser>(dto);

            user.Salt = GenerateRandomCode.GetCode(5);
            user.Password = user.Password.Salted(user.Salt);
            user.Enable = 1;
            user.Status = 1;
            user.ErrorCount = 0;
            var currentTime = DateTime.Now;
            user.LoginTime = currentTime;
            user.PwdUpdateTime = currentTime;
            user.CreateTime = currentTime;
            user.UpdateTime = currentTime;
            user.CreateBy = _aspNetUser.Id;
            user.UpdateBy = _aspNetUser.Id;

            return await _userRepository.InsertAsync(user);
        }

        /// <summary>
        /// 更新使用者資訊
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> UpdateUser(SysUserDto dto)
        {
            var user = _mapper.Map<SysUser>(dto);

            user.UpdateTime = DateTime.Now;
            user.UpdateBy = _aspNetUser.Id;

             return await _userRepository.UpdateAsync(user,
                c => c.Name,
                c => c.DeptId,
                c => c.Phonenumber,
                c => c.Email,
                c => c.Enable,
                c => c.UpdateTime,
                c => c.UpdateBy);
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<int> DeleteUser(int Id)
        {
            if (Id <= LimitAdminId)
            {
                throw new BusinessException("禁止變更管理員");
            }

            return await _userRepository.UpdateAsync(new SysUser
            {
                Id = Id,
                Status = 0,
            });
        }

        /// <summary>
        /// 切換使用者狀態
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<int> ChangeStatus(int Id)
        {
            if (Id <= LimitAdminId)
            {
                throw new BusinessException("禁止變更管理員");
            }

            var user = await _userRepository.FetchAsync(c => c.Id == Id);
            if (user == null)
            {
                throw new BusinessException("無此使用者");
            }

            user.Status = user.Status == 1 ? 0 : 1;
            return await _userRepository.UpdateAsync(user, c => c.Status);
        }

        /// <summary>
        /// 設定使用者權限
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public async Task<int> SetRoles(int Id, List<int> RoleIds)
        {
            if (Id <= LimitAdminId)
            {
                throw new BusinessException("無此使用者");
            }

            return await _userRoleRepository.SetRolesByUseId(Id, RoleIds);
        }

        /// <summary>
        /// 取得使用者 By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<SysUser> GetUser(int Id)
        {
            var user = await _userRepository.FetchAsync(c => c.Id == Id);

            if (user == null)
            {
                throw new BusinessException("無此使用者");
            }

            return user;
        }
    }
}
