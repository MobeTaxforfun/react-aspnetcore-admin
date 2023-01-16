
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using ZoneCore.Infra.DataAccess.EFCore.Query;

namespace ZoneCore.Infra.DataAccess.EFCore
{
    public interface IGenericRepository<TDbContext, TEntity> : IRepository
        where TDbContext : DbContext
        where TEntity : class
    {
        void ClearTrack(TEntity entity);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
        Task<List<TEntity>> ListedAsync(Expression<Func<TEntity, bool>> whereExpression);
    }
}
