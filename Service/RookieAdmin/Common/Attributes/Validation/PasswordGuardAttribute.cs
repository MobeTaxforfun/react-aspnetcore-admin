using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RookieAdmin.Common.Attributes.Validation
{
    /// <summary>
    /// 驗證密碼規則
    /// </summary>
    public class PasswordGuardAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("密碼不可為空");
            string password = (string)value;

            List<bool> bools = new List<bool>();
            // 大寫英文、小寫英文、數字、特殊符號 4 取 3
            bools.Add(Regex.Match(password, @"^(?=.*\d).*").Success); //數字
            bools.Add(Regex.Match(password, @"^(?=.*[a-z]).*").Success); // 小寫EN
            bools.Add(Regex.Match(password, @"^(?=.*[A-Z]).*").Success); // 大寫en
            bools.Add(Regex.Match(password, @"^(?=.*\W).*").Success); // 特殊字元

            if (bools.Count(c => c == true) >= 3)
                return ValidationResult.Success;

            return new ValidationResult("密碼組成必須符合，大寫英文、小寫英文、數字、特殊符號中任3項");
        }
    }
}
