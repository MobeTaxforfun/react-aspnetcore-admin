using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZoneCore.Infra.DataAccess.EFCore.Context
{
    public interface IGenericEFExecute
    {
        void ClearTrack<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> DeleteAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> InsertAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> UpdateAsync<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] properties) where TEntity : class;
    }
}
