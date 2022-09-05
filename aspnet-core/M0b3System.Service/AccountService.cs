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
        public Task<SignInStatus> PasswordSignInAsync(string UserName, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
