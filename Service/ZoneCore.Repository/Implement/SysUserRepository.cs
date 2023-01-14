using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.EFCore;
using ZoneCore.Models.Entity;
using ZoneCore.Repository.Interface;

namespace ZoneCore.Repository.Implement
{
    public class SysUserRepository : GenericRepository<SystemDbContext, SysUser>, ISysUserRepository
    {
        public SysUserRepository(SystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
