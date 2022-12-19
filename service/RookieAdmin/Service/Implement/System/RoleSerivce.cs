using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookieAdmin.Common.Instances;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Repository.Implement;
using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Interface.System;
using RookieAdmin.ViewModels.System;
using static RookieAdmin.Common.Permission.SystemCert;

namespace RookieAdmin.Service.Implement.System
{
    public class RoleSerivce : IRoleSerivce
    {
        private readonly IMapper _mapper;
        private readonly IAspNetUser _aspNetUser;
        private readonly IRoleRepository _roleRepository;
        public RoleSerivce(
            IMapper mapper,
            IAspNetUser aspNetUser,
            IRoleRepository roleRepository)
        {
            this._mapper = mapper;
            this._aspNetUser = aspNetUser;
            this._roleRepository = roleRepository;
        }

        public async Task<List<SysRole>> ListedRole()
        {
            return (await _roleRepository.ToListAsync()).OrderBy(c => c.Sort).ToList();
        }

        public async Task<int> CreateRole(SysRoleDto dto)
        {
            var role = _mapper.Map<SysRole>(dto);

            role.CreateTime = DateTime.Now;
            role.CreateBy = _aspNetUser.Id;
            role.UpdateTime = DateTime.Now;
            role.UpdateBy = _aspNetUser.Id;

            return await _roleRepository.InsertAsync(role);
        }

        public async Task<int> DeleteRole(int Id)
        {
            return await _roleRepository.DeleteAsync(new SysRole
            {
                Id = Id
            });
        }

        public async Task<int> UpdateRole(SysRoleDto dto)
        {
            var role = _mapper.Map<SysRole>(dto);

            role.UpdateTime = DateTime.Now;
            role.UpdateBy = _aspNetUser.Id;

            return await _roleRepository.UpdateAsync(role,
                c => c.RoleName,
                c => c.RoleCode,
                c => c.Sort,
                c => c.Status,
                c => c.Remark);
        }

        public Task<PagedModel<SysRole>> PaginateRole(RoleSearchModel model)
        {
            throw new NotImplementedException();
        }
    }
}
