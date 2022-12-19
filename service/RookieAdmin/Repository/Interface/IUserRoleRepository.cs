using RookieAdmin.Models.Entity;

namespace RookieAdmin.Repository.Interface
{
    public interface IUserRoleRepository : IGenericRepository<RookieAdminDbContext, SysUserRole>
    {
        public Task<int> SetRolesByUseId(int UserId, List<int> Role);
    }
}
