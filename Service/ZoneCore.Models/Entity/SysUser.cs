using System;
using System.Collections.Generic;

namespace ZoneCore.Models.Entity
{
    public partial class SysUser
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 加鹽
        /// </summary>
        public string Salt { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 部門ID
        /// </summary>
        public int DeptId { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// 電話
        /// </summary>
        public string Phonenumber { get; set; } = null!;
        /// <summary>
        /// 頭像路徑
        /// </summary>
        public string? Avatar { get; set; }
        /// <summary>
        /// 是否啟用(0 否 1 是)
        /// </summary>
        public int Enable { get; set; }
        /// <summary>
        /// 是否刪除(0 已刪除 1 使用中)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 登入錯誤次數
        /// </summary>
        public int ErrorCount { get; set; }
        /// <summary>
        /// 上次登入時間
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 最後密碼更新時間
        /// </summary>
        public DateTime PwdUpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateBy { get; set; }
    }
}
