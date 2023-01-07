using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Account;

namespace RookieAdmin.Service.Interface
{
    public interface IAccountService
    {
        public Task<SignInResultModel> PasswordSignInAsync(string Account, string Password);
        public Task<SignInResultModel> PasswordSignInAsync(SysUser user, string Password);
    }
}
