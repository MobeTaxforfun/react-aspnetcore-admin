using System.ComponentModel.DataAnnotations;

namespace RookieAdmin.Common.Attributes.Validation
{
    /// <summary>
    /// 驗證是否有全形與中文
    /// </summary>
    public class UnicodeGuardAttribute : RegularExpressionAttribute
    {
        /// <summary>
        /// 只允許指定範圍的 Unicode 通過
        /// </summary>
        public UnicodeGuardAttribute() : base(@"[\x00-\x7F]+")
        {

        }
    }
}
