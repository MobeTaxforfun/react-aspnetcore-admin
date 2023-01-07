using RookieAdmin.Common.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace RookieAdmin.ViewModels.System
{
    public class UserViewModel
    {
    }

    /// <summary>
    /// 基本類別
    /// </summary>
    public class BaseUserVM
    {
        [Required(ErrorMessage = "帳號為必填")]
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 部門ID
        /// </summary>
        public int DeptId { get; set; }
        [Required(ErrorMessage = "電子郵件為必填")]
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "電話為必填")]
        /// <summary>
        /// 電話
        /// </summary>
        public string Phonenumber { get; set; } = null!;
    }

    /// <summary>
    /// 接收創建使用者
    /// </summary>
    public class CreateUserVM : BaseUserVM
    {
        [Required(ErrorMessage = "帳號為必填")]
        [RegularExpression(@"^\S*$", ErrorMessage = "使用者帳號不允許空白")]
        [UnicodeGuard(ErrorMessage = "使用者帳號不允許輸入中文、全形")]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = null!;
    }

    /// <summary>
    /// 接收更新使用者
    /// </summary>
    public class UpdateUserVM : BaseUserVM
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// 更新使用者角色
    /// </summary>
    public class SetUserRolesVM
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; } = default!;

    }


}
