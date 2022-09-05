using M0b3System.Dto.Dto;
using M0b3System.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Service.Contract
{
    public interface IAccountService : IService
    {
        public Task<(SignInStatus, SysUserDto?)> PasswordSignInAsync(string UserName, string Password);
    }
}
