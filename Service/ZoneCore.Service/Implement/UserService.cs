using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Models.Dto;
using ZoneCore.Models.Entity;
using ZoneCore.Models.Model;
using ZoneCore.Repository.Implement;
using ZoneCore.Repository.Interface;
using ZoneCore.Service.Interface;

namespace ZoneCore.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ISysUserRepository _sysUserRepository;

        public UserService(IMapper mapper, ISysUserRepository sysUserRepository)
        {
            this._mapper = mapper;
            this._sysUserRepository = sysUserRepository;
        }

        public Task<int> CreateUser(UserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUser(int Id)
        {
            throw new NotImplementedException();
        }

        public void ListedUser()
        {
            //_sysUserRepository.ListedAsync();
        }

        public Task<List<UserDto>> PaginateUser(UseSearchParameter model)
        {
            throw new NotImplementedException();
        }

        public Task<int> SetUserRole(int UserId, List<int> RoleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SetUserState(UserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
