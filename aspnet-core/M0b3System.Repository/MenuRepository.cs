using M0b3System.Entity;
using M0b3System.Infrastructure.Contract;
using M0b3System.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Repository
{
    public class MenuRepository : GenericEFRepository<SystemManageDbContext, SysMenu>, IMenuRepository
    {
        public MenuRepository(SystemManageDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
