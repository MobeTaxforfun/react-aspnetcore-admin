namespace RookieAdmin.Models
{
    /// <summary>
    /// 基本訊息
    /// </summary>
    public class MessageAPI
    {
        /// <summary>
        /// 狀態
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 提示
        /// </summary>
        public string Message { get; set; } = "";
    }

    /// <summary>
    /// 訊息加物件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageAPI<T> : MessageAPI
    {
        /// <summary>
        /// 可傳遞的資料
        /// </summary>
        public T? Data { get; set; }
    }


    /// <summary>
    /// 模型驗證失敗用
    /// </summary>
    public class MessageValidFailed : MessageAPI
    {
        /// <summary>
        /// ModelStateErrors 轉 Dictionary
        /// </summary>
        public Dictionary<string, string[]>? ModelStateErrors { get; set; }
    }

}
