using Dapper;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Repository.DataAccess;
using RookieAdmin.Repository.Interface;

namespace RookieAdmin.Repository.Implement
{
    public class UserRepository : GenericRepository<RookieAdminDbContext, SysUser>, IUserRepository
    {
        public UserRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(int TotalCount, List<SysUser> Data)> PaginateUser(UserSearchModel model)
        {
            string countSql = @" Select Count(*) 
                                    From [SysUser] 
                                    Where [Status] = 1 ";

            string mainSql = @" Select * 
                                From [SysUser]  
                                Where [Status] = 1 ";

            DynamicParameters parameters = new DynamicParameters();

            if (model.DeptId.HasValue)
            {
                countSql += " And DeptId = @DeptId ";
                mainSql += " And DeptId = @DeptId ";
                parameters.Add("DeptId", model.DeptId.Value);
            }

            if (!string.IsNullOrEmpty(model.Account))
            {
                countSql += " AND Account like '%' + @Account + '%'";
                mainSql += " AND Account like '%' + @Account + '%'";
                parameters.Add("Account", model.Account);
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                countSql += " AND [Name] like '%' + @UserName + '%'";
                mainSql += " AND [Name] like '%' + @UserName + '%'";
                parameters.Add("UserName", model.Name);
            }

            int max = await this.DbContext.Database.DapperQueryFirstOrDefaultAsync<int>(countSql, parameters);

            mainSql += @" Order by [User].CreateTime desc " + @" Offset @skip Rows" + @" Fetch Next @take Rows Only ";

            parameters.Add("skip", model.ItemsPerPage * model.Page);
            parameters.Add("take", model.ItemsPerPage);

            return (max, (await this.DbContext.Database.DapperQueryAsync<SysUser>(mainSql, parameters)).ToList());
        }
    }
}
