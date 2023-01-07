namespace RookieAdmin.Models.Model.Search
{
    public class UserSearchModel : PageParameterModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        public int? DeptId { get; set; }
    }
}
