using M0b3System.Entity;
using M0b3System.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Repository.Contract
{
    public interface IMenuRepository : IGenericEFRepository<SystemManageDbContext, SysMenu>
    {
    }
}
