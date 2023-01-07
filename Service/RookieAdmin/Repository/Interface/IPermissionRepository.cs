using RookieAdmin.Models.Entity;
using System.Security;

namespace RookieAdmin.Repository.Interface
{
    public interface IPermissionRepository : IGenericRepository<RookieAdminDbContext, SysPermission>
    {
    }
}
