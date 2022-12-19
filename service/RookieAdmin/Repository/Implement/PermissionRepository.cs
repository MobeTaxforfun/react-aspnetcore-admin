using RookieAdmin.Models.Entity;
using RookieAdmin.Repository.DataAccess;
using RookieAdmin.Repository.Interface;

namespace RookieAdmin.Repository.Implement
{
    public class PermissionRepository : GenericRepository<RookieAdminDbContext, SysPermission>, IPermissionRepository
    {
        public PermissionRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<string>> ListedPermissionCodeByRoleId(int RoleId)
        {
            string mainsql = @"Select sm.PermsCode
                                From [SysPermission] as sp
                                Join [SysMenu] as sm on sp.MenuId = sm.Id
                                Where sm.MenuType = 3 And sp.RoleId = @RoleId";

            return (await this.DbContext.Database.DapperQueryAsync<string>(mainsql, new { RoleId })).ToList();
        }
    }
}
