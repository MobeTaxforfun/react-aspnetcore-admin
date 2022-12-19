namespace RookieAdmin.Models.Dto
{
    public class SysRoleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        public string RoleName { get; set; } = null!;
        /// <summary>
        /// 權限標記
        /// </summary>
        public string RoleCode { get; set; } = null!;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 狀態(0 不啟用, 1 啟用)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remark { get; set; }
    }
}
