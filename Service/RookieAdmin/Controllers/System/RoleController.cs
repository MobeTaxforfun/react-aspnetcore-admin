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
        private readonly IRoleService _roleSerivce;

        public RoleController(
            IMapper mapper,
            IRoleService roleSerivce)
        {
            this._mapper = mapper;
            this._roleSerivce = roleSerivce;
        }

        [HttpGet("Paginate")]
        public async Task<IActionResult> ListedRoles([FromQuery] RoleSearchModel model)
        {
            model.Page = (model.Page ?? 1) - 1;
            return Successful(data: await _roleSerivce.PaginateRole(model));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveRole(int Id)
        {
            return DataChanges(await _roleSerivce.DeleteRole(Id), "刪除");
        }

        [HttpPost]
        [GlobalModelStateFilter]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleVM model)
        {
            return DataChanges(await _roleSerivce.CreateRole(_mapper.Map<SysRoleDto>(model)), "新增");
        }

        [HttpPut]
        [GlobalModelStateFilter]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleVM model)
        {
            return DataChanges(await _roleSerivce.UpdateRole(_mapper.Map<SysRoleDto>(model)), "更新");
        }

        [HttpPut("SetStatus")]
        public async Task<IActionResult> SetRoleStatus([FromBody] UpdateRoleStatusVM model)
        {
            return DataChanges(await _roleSerivce.SetRoleStatus(model.Id, model.Status), "變更");
        }
    }
}
