namespace RookieAdmin.Common.Permission
{
    /// <summary>
    /// 為減少人為的低端失誤，將資料庫的 Permission Code 以參數型式存放
    /// </summary>
    public class PermitOption
    {
        // 留得青山在不怕沒柴燒
    }

    /// <summary>
    /// 系統權限的 Permission Code 以小寫為主，認證時程式內會轉成小寫對應
    /// </summary>
    public static class SystemCert
    {
        public const string GroupName = ".system";

        /// <summary>
        /// 帳號管理
        /// </summary>
        public static class User
        {
            public const string Default = GroupName + "_user";
            public const string View = Default + "_view";
        }

        /// <summary>
        /// 權限管理
        /// </summary>
        public static class Role
        {
            public const string Default = GroupName + "_user";
            public const string View = Default + "_view";
        }

        /// <summary>
        /// 選單管理
        /// </summary>
        public static class Menu
        {
            public const string Default = GroupName + "_user";
            public const string View = Default + "_view";
        }
    }

}
