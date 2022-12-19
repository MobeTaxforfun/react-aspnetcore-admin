using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RookieAdmin.Common.AppAuthorize;
using RookieAdmin.Common.Attributes;
using RookieAdmin.Controllers.Basic;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Service.Interface.System;
using RookieAdmin.ViewModels.System;

namespace RookieAdmin.Controllers.System
{
    public class RoleController : BaseAuthController
    {
        private readonly IMapper _mapper;
        private readonly IRoleSerivce _roleSerivce;

        public RoleController(
            IMapper mapper,
            IRoleSerivce roleSerivce)
        {
            this._mapper = mapper;
            this._roleSerivce = roleSerivce;
        }

        [Permission("test")]
        [HttpGet("Listed")]
        public async Task<IActionResult> ListedRoles([FromQuery]RoleSearchModel model)
        {
            return Successful(data: await _roleSerivce.ListedRole());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveRole(int Id)
        {
            return DataChanges(await _roleSerivce.DeleteRole(Id), "刪除");
        }

        [HttpPost]
        [GlobalModelStateFilter]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleVM model)
        {
            return DataChanges(await _roleSerivce.CreateRole(_mapper.Map<SysRoleDto>(model)), "新增");
        }

        [HttpPut]
        [GlobalModelStateFilter]
        public async Task<ActionResult> UpdateRole([FromBody] CreateRoleVM model)
        {
            return DataChanges(await _roleSerivce.UpdateRole(_mapper.Map<SysRoleDto>(model)), "更新");
        }
    }
}
