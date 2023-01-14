using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Infra.DataAccess.EFCore.Query
{
    public class GenericEFQuery<TDbContext>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public GenericEFQuery(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> whereExpression)
            where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Where(whereExpression).ToList();
        }
    }
}
