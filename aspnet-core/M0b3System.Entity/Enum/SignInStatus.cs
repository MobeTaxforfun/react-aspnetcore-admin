using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Entity.Enum
{
    public enum SignInStatus
    {
        [Description("登入成功")]
        Failure = 0,
        [Description("登入失敗，請確定您的帳號或密碼")]
        Success = 1,
        [Description("登入失敗，帳號已被鎖定")]
        LockedOut = 2,
        [Description("無權限")]
        StatusError = 3,
    }
}
