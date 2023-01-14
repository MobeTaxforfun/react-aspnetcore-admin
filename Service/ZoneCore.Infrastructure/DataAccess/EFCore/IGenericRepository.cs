
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using ZoneCore.Infra.DataAccess.EFCore.Query;

namespace ZoneCore.Infra.DataAccess.EFCore
{
    public interface IGenericRepository<TDbContext, TEntity> : IGenericEF
        where TDbContext : DbContext
        where TEntity : class
    {
        void ClearTrack(TEntity entity);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
        List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression);
    }
}
