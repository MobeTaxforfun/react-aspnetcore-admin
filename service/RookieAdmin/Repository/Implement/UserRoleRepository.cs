using RookieAdmin.Models.Entity;
using RookieAdmin.Repository.DataAccess;
using RookieAdmin.Repository.Interface;

namespace RookieAdmin.Repository.Implement
{
    public class UserRoleRepository : GenericRepository<RookieAdminDbContext, SysUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> SetRolesByUseId(int UserId, List<int> Role)
        {
            int dbCount = 0;

            using (var trans = DbContext.Database.BeginTransaction())
            {
                try
                {
                    string deleteSql = @"Delete From [SysUserRole] Where UserId = @UserId";
                    await this.DbContext.Database.DapperExecuteAsync(deleteSql, new { UserId });

                    string insertSql = @"INSERT INTO [SysUserRole]
                                               ([UserId]
                                               ,[RoleId])
                                         VALUES
                                               (@UserId
                                               ,@RoleId";

                    List<SysUserRole> sysUserRoles = new List<SysUserRole>();

                    foreach (var item in Role)
                    {
                        sysUserRoles.Add(new SysUserRole
                        {
                            UserId = UserId,
                            RoleId = item
                        });
                    }

                    dbCount = await this.DbContext.Database.DapperExecuteAsync(insertSql, sysUserRoles);
                    await trans.CommitAsync();
                }
                catch (Exception)
                {
                    await trans.RollbackAsync();
                }
            }

            return dbCount;
        }
    }
}
