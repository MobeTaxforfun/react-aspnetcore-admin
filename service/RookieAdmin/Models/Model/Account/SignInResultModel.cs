using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Enum;

namespace RookieAdmin.Models.Model.Account
{
    /// <summary>
    /// 登入後輸出
    /// </summary>
    public class SignInResultModel
    {
        /// <summary>
        /// 登入結果
        /// </summary>
        public LoginResult Result { get; set; }

        /// <summary>
        /// 登入成功，取得使用者資料，其餘為 NULL
        /// </summary>
        public SignInContextModel? CurrentUser { get; set; }

        /// <summary>
        /// 登入失敗次數(備用)
        /// </summary>
        public int ErrorCount { get; set; } = 0;

    }
}
