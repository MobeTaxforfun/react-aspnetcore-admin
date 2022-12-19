using RookieAdmin.Models.Entity;
using RookieAdmin.Repository.Interface;

namespace RookieAdmin.Repository.Implement
{
    public class RoleRepository : GenericRepository<RookieAdminDbContext, SysRole>, IRoleRepository
    {
        public RoleRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }
    }
}
