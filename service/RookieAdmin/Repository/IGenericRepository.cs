using Microsoft.EntityFrameworkCore;
using RookieAdmin.Models.Model;
using System.Linq.Expressions;

namespace RookieAdmin.Repository
{
    public interface IGenericRepository<TDbContext, TEntity>
      where TDbContext : DbContext
      where TEntity : class
    {
        void ClearTrack(TEntity entity);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        bool Exist(Expression<Func<TEntity, bool>> whereExpression);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
        TEntity? Fetch(Expression<Func<TEntity, bool>> whereExpression);
        Task<TEntity?> FetchAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
        int Insert(IEnumerable<TEntity> entities);
        int Insert(TEntity entity);
        Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        List<TEntity> Listed();
        Task<PagedModel<TEntity>> PagedAsync<TProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false, CancellationToken cancellationToken = default);
        List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync();
        int Update(TEntity entity);
        int Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
    }
}
