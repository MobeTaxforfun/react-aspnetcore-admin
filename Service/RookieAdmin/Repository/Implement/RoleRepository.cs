using Dapper;
using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;
using RookieAdmin.Repository.DataAccess;
using RookieAdmin.Repository.Interface;

namespace RookieAdmin.Repository.Implement
{
    public class RoleRepository : GenericRepository<RookieAdminDbContext, SysRole>, IRoleRepository
    {
        public RoleRepository(RookieAdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(int max, List<SysRoleDto> data)> PaginateRole(RoleSearchModel model)
        {
            string countSql = @"Select Count(*) From SysRole Where 1 = 1";
            string mainSql = @"Select * From SysRole Where 1 = 1 ";

            DynamicParameters parameters = new DynamicParameters();

            if (model.Status.HasValue)
            {
                countSql += " And [Status] = @Status ";
                mainSql += " And [Status] = @Status ";
                parameters.Add("Status", model.Status.Value);
            }

            if (!string.IsNullOrEmpty(model.RoleName))
            {
                countSql += " AND [RoleName] like '%' + @RoleName + '%' ";
                mainSql += " AND [RoleName] like '%' + @RoleName + '%' ";
                parameters.Add("RoleName", model.RoleName);
            }

            if (!string.IsNullOrEmpty(model.RoleCode))
            {
                countSql += " AND [RoleCode] like '%' + @RoleCode + '%' ";
                mainSql += " AND [RoleCode] like '%' + @RoleCode + '%' ";
                parameters.Add("RoleCode", model.RoleCode);
            }

            int max = await this.DbContext.Database.DapperQueryFirstOrDefaultAsync<int>(countSql, parameters);

            mainSql += @" Order by Sort asc " + @" Offset @skip Rows" + @" Fetch Next @take Rows Only ";
            parameters.Add("skip", model.ItemsPerPage * model.Page);
            parameters.Add("take", model.ItemsPerPage);

            return (max, (await this.DbContext.Database.DapperQueryAsync<SysRoleDto>(mainSql, parameters)).ToList());

        }
    }
}
