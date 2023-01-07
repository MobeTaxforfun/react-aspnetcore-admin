namespace RookieAdmin.Models.Model.Account
{
    /// <summary>
    /// !!!
    /// 不該在此 Model 出現可為 Null 的 Field 建議都加個初始化參數
    /// !!!
    /// </summary>
    public class SignInContextModel
    {
        public string Account { get; set; } = string.Empty;
    }
}
