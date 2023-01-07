namespace RookieAdmin.ViewModels.System
{
    public class MenuViewModel
    {

    }

    public class CreateMenuVM
    {
        /// <summary>
        /// 選單名稱
        /// </summary>
        public string MenuName { get; set; } = null!;
        /// <summary>
        /// 父節點Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 打開方式(0 頁籤, 1 另開新視窗)
        /// </summary>
        public int? Target { get; set; }
        /// <summary>
        /// 類型 ( 0 目錄, 1 選單, 2 功能)
        /// </summary>
        public int MenuType { get; set; }
        /// <summary>
        /// 是否顯示(0 不顯示, 1 顯示)
        /// </summary>
        public int IsEnable { get; set; }
        /// <summary>
        /// 權限標記
        /// </summary>
        public string PermsCode { get; set; } = null!;
        /// <summary>
        /// ICON圖示
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 備註
        /// </summary>
        public string? ReMark { get; set; }
    }

    public class UpdateMenuVM : CreateMenuVM
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
