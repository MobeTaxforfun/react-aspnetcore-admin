using RookieAdmin.Models.Entity;

namespace RookieAdmin.Repository.Interface
{
    public interface IMenuRepository : IGenericRepository<RookieAdminDbContext, SysMenu>
    {
    }
}
