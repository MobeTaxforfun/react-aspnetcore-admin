using M0b3System.Dto.Dto;
using M0b3System.Entity.Enum;
using M0b3System.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Service
{
    public class AccountService : IAccountService
    {

        public async Task<(SignInStatus, SysUserDto?)> PasswordSignInAsync(string UserName, string Password)
        {
            return new(SignInStatus.Success, new SysUserDto
            {
                Id = 1,
                Account = "Test",
                Email = "Test@mail.com",
                Role = "admin",
                UserName = "TestWu",
                RoleId = 1
            });
        }
    }
}
