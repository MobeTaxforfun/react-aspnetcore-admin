namespace ZoneCore.Web.ViewModels
{
    public class SysUserVM
    {
    }

    public class UpdateUserRoleVM
    {
        public int UserId { get; set; }
        public List<int> RoleId { get; set; } = null!;
    }
}
