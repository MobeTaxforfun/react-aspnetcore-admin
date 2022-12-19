using RookieAdmin.Models.Entity;

namespace RookieAdmin.Repository.Implement
{
    public class MenuRepository : GenericRepository<RookieAdminDbContext, SysMenu>
    {
        public MenuRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }
    }
}
