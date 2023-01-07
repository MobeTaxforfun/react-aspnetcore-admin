using RookieAdmin.Models.Dto;
using RookieAdmin.Models.Entity;
using RookieAdmin.Models.Model.Search;

namespace RookieAdmin.Repository.Interface
{
    public interface IRoleRepository : IGenericRepository<RookieAdminDbContext, SysRole>
    {
        public Task<(int max, List<SysRoleDto> data)> PaginateRole(RoleSearchModel model);
    }
}
