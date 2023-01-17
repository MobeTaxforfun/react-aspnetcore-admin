using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Models.Entity;
using ZoneCore.Models.Model;
using ZoneCore.Service.Interface;

namespace ZoneCore.Service.Implement
{
    public class AccountService : IAccountService
    {
        public Task<SignInResultModel> PasswordSignInAsync(string Account, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResultModel> PasswordSignInAsync(SysUser user, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
