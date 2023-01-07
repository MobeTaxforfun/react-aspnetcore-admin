namespace RookieAdmin.Models.Model
{
    public class PagedModel
    {
    }

    public class PageParameterModel
    {
        /// <summary>
        /// 頁數
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 每頁幾筆
        /// </summary>
        public int ItemsPerPage { get; set; } = 10;
    }

    public class PagedModel<T>
    {
        /// <summary>
        /// 資料列表本人
        /// </summary>
        public List<T> TableData { get; set; } = default!;

        /// <summary>
        /// 列表總數用來計算頁數
        /// </summary>
        public int TotalCount { get; set; }

    }
}
