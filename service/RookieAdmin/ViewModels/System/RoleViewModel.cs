using System.ComponentModel.DataAnnotations;

namespace RookieAdmin.ViewModels.System
{
    public class RoleViewModel
    {
    }

    public class BaseRoleVM
    {
        /// <summary>
        /// 角色名稱
        /// </summary>
        [Required(ErrorMessage = "角色名稱為必填")]
        public string RoleName { get; set; } = null!;
        [Required(ErrorMessage = "權限標記為必填")]
        /// <summary>
        /// 權限標記
        /// </summary>
        public string RoleCode { get; set; } = null!;
        [Required(ErrorMessage = "排序為必填")]
        [Range(0, int.MaxValue, ErrorMessage = "排序必須為數字")]
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

    public class CreateRoleVM : BaseRoleVM
    {

    }

    public class UpdateRoleVM : BaseRoleVM
    {
        public int Id { get; set; }
    }
}
