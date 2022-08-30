using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Infrastructure.Contract
{
    public interface IGenericEFRepository<out TDbContext, TEntity> 
    where TDbContext : DbContext
    where TEntity : class
    {
    }
}
