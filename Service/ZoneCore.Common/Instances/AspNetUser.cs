using Microsoft.AspNetCore.Http;

namespace ZoneCore.Common.Instances
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        #region 你可能不會想看這個
        public int Id => _Id;
        private int _Id = 0;

        public string Account => _Account;
        private string _Account = string.Empty;

        public string Name => _Name;
        private string _Name = string.Empty;

        public string Phonenumber => _Phonenumber;
        private string _Phonenumber = string.Empty;

        public string Email => _Email;
        private string _Email = string.Empty;

        public int DeptId => _DeptId;
        private int _DeptId = 0;

        public int RoleId => _RoleId;
        private int _RoleId = 0;

        public string RoleName => _RoleName;
        private string _RoleName = string.Empty;

        #endregion

        public AspNetUser(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public void LoadUserInfo()
        {
            throw new NotImplementedException();
        }
    }

    public interface IAspNetUser
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; }
        /// 電話
        /// </summary>
        public string Phonenumber { get; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// 單位ID
        /// </summary>
        public int DeptId { get; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleName { get; }

        /// <summary>
        /// 載入使用者資料
        /// </summary>
        public void LoadUserInfo();
    }
}
