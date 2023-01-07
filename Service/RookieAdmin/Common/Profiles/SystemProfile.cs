using AutoMapper;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.ViewModels.System;

namespace RookieAdmin.Common.Profiles
{
    /// <summary>
    /// 用於 Systems 的資料映射
    /// </summary>
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {

        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserVM, SysUserDto>();
            CreateMap<UpdateUserVM, SysUserDto>();
            CreateMap<SysUserDto, SysUser>();
        }
    }

    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleVM, SysRoleDto>();
            CreateMap<UpdateRoleVM, SysRoleDto>();
            CreateMap<SysRoleDto, SysRole>();
            CreateMap<SysRoleIdAndNameDto, SysRole>().ReverseMap();
        }
    }
}
