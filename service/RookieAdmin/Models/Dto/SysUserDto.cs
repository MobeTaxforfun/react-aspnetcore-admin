namespace RookieAdmin.Models.Dto
{
    public class SysUserDto
    {
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = null!;
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
    }
}
