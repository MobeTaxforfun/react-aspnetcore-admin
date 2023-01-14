using ZoneCore.Infra.DataAccess.EFCore;
using ZoneCore.Models.Entity;

namespace ZoneCore.Repository.Interface
{
    public interface ISysUserRepository : IGenericRepository<SystemDbContext,SysUser>
    {
    }
}
