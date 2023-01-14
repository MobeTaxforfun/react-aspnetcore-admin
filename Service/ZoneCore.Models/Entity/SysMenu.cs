using System;
using System.Collections.Generic;

namespace ZoneCore.Models.Entity
{
    public partial class SysMenu
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 選單名稱
        /// </summary>
        public string MenuName { get; set; } = null!;
        /// <summary>
        /// 父節點Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 打開方式(1 頁籤, 2 另開新視窗)
        /// </summary>
        public int? Target { get; set; }
        /// <summary>
        /// 類型 ( 1 目錄, 2 選單, 3 功能)
        /// </summary>
        public int MenuType { get; set; }
        /// <summary>
        /// 是否顯示(0 不顯示, 1 顯示)
        /// </summary>
        public int IsEnable { get; set; }
        /// <summary>
        /// 權限標記
        /// </summary>
        public string PermsCode { get; set; } = null!;
        /// <summary>
        /// ICON圖示
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 備註
        /// </summary>
        public string? ReMark { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateBy { get; set; }
    }
}
