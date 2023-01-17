using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Models.Entity;
using ZoneCore.Models.Model;

namespace ZoneCore.Service.Interface
{
    public interface IAccountService
    {
        public Task<SignInResultModel> PasswordSignInAsync(string Account, string Password);
        public Task<SignInResultModel> PasswordSignInAsync(SysUser user, string Password);
    }
}
