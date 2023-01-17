using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Models.Enum;

namespace ZoneCore.Models.Model
{
    public class AccountModel
    {

    }

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
    }

    public class SignInContextModel
    {
        public string UserName { get; set; } = null!;
    }
}
