using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Dto.Dto
{
    public class BaseDto<T> where T : notnull
    {
        public T Id { get; set; }

        /// <summary>
        /// 創建者
        /// </summary>
        [Description("創建者")]
        public long? CreatedUser { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Description("建立時間")]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// 最後更新者
        /// </summary>
        [Description("最後更新者")]
        public long? UpdatedUser { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Description("更新時間")]
        public DateTime? UpdatedTime { get; set; }
    }
}
