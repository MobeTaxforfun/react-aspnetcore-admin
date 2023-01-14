using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ZoneCore.Infra.DataAccess.EFCore.Query
{
    public interface IGenericEFQuery
    {
        List<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;
    }
}
