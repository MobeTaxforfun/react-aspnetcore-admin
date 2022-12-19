using Dapper;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;

namespace RookieAdmin.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<RookieAdminDbContext, SysUser>
    {
        public Task<(int TotalCount, List<SysUser> Data)> PaginateUser(UserSearchModel model);
    }
}
