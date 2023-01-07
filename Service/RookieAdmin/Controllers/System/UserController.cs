using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Common.Attributes;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Service.Interface.System;
using RookieAdmin.ViewModels.System;

namespace RookieAdmin.Controllers.System
{
    public class UserController : BaseAuthController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(
            IMapper mapper,
            IUserService userService)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet("Listed")]
        public async Task<IActionResult> ListedUser([FromQuery] UserSearchModel model)
        {
            return Successful(await _userService.PaginateUser(model));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            return Successful(await _userService.GetUser(Id));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            return DataChanges(await _userService.DeleteUser(Id), "刪除");
        }

        [HttpPost]
        [GlobalModelStateFilter]
        public async Task<IActionResult> CreateUser(CreateUserVM model)
        {
            return DataChanges(await _userService.CreateUser(_mapper.Map<SysUserDto>(model)), "新增");
        }

        [HttpPut]
        [GlobalModelStateFilter]
        public async Task<IActionResult> UpdateUser(UpdateUserVM model)
        {
            return DataChanges(await _userService.UpdateUser(_mapper.Map<SysUserDto>(model)), "更新");
        }

        [HttpPost("SetUserRoles")]
        public async Task<IActionResult> SetUserRoles([FromBody] SetUserRolesVM model)
        {
            return DataChanges(await _userService.SetRoles(model.UserId, model.RoleIds), "更新");
        }

        [HttpPut("MotifyStatus")]
        public async Task<IActionResult> MotifyStatus(int Id)
        {
            return DataChanges(await _userService.ChangeStatus(Id), "變更");
        }

    }
}
