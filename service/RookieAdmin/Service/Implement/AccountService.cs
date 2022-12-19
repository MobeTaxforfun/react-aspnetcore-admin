using RookieAdmin.Common.Extension.Security;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Enum;
using RookieAdmin.Models.Model.Account;
using RookieAdmin.Repository.Implement;
using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Interface;

namespace RookieAdmin.Service.Implement
{
    /// <summary>
    /// 各種尚未登入時，對使用者的操作，包含 : 登入(完成)、忘記密碼、註冊新帳號...等
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 登入 ( Entity, 密碼 )
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SignInResultModel> PasswordSignInAsync(SysUser user, string Password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // 先驗證各種狀態在驗證密碼
            if (user.Enable == 0 || user.Status == 0)
            {
                return new SignInResultModel
                {
                    Result = LoginResult.LockedOut
                };
            }

            // 驗證加鹽密碼
            if (user.Password != Password.Salted(user.Salt))
            {
                return new SignInResultModel
                {
                    Result = LoginResult.Failure
                };
            }

            //登入成功就寫一個 Log
            user.LoginTime = DateTime.Now;
            await _userRepository.UpdateAsync(user, c => c.LoginTime);

            return new SignInResultModel
            {
                Result = LoginResult.Success,
                CurrentUser = new SignInContextModel
                {
                    Account = user.Account
                }
            };
        }

        /// <summary>
        /// 登入 ( 帳號, 密碼 )
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<SignInResultModel> PasswordSignInAsync(string Account, string Password)
        {
            var user = await _userRepository.FetchAsync(c => c.Account == Account);

            // 驗證無使用者
            if (user == null)
            {
                return new SignInResultModel
                {
                    Result = LoginResult.Failure
                };
            }

            return await PasswordSignInAsync(user, Password);
        }
    }
}
