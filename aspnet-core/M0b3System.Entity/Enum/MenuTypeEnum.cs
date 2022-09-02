using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Entity.Enum
{
    public enum MenuTypeEnum
    {
        [Description("目錄")]
        Directory = 1,

        [Description("頁面")]
        Menu = 2,

        [Description("功能")]
        Button = 3
    }
}
