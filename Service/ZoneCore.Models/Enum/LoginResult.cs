using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Models.Enum
{
    public enum LoginResult
    {
        [Description("登入失敗，請確定您的帳號密碼是否正確")]
        Failure = 0,
        [Description("登入成功")]
        Success = 1,
        [Description("此帳號尚未認證")]
        RequiresVerification = 2,
        [Description("此帳號已被鎖定")]
        LockedOut = 3,
        [Description("無權限登入")]
        StatusError = 4,
    }
}
