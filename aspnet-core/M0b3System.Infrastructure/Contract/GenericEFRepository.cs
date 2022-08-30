using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Infrastructure.Contract
{
    public abstract class GenericEFRepository<TDbContext, TEntity> : IGenericEFRepository<TDbContext, TEntity>
    where TDbContext : DbContext
    where TEntity : class
    {
        public TDbContext DbContext { get; }

        public GenericEFRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity? Find(params object[] keyValues)
        {
            return DbContext.Find<TEntity>(keyValues);
        }

        public virtual async ValueTask<TEntity?> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await DbContext.FindAsync<TEntity>(keyValues);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().Count(whereExpression);

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)   => DbContext.Set<TEntity>().CountAsync(whereExpression, cancellationToken);

        public virtual long LongCount(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().LongCount(whereExpression);

        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) => DbContext.Set<TEntity>().LongCountAsync(whereExpression, cancellationToken);

        public virtual bool Exist(Expression<Func<TEntity, bool>> whereExpression) =>  DbContext.Set<TEntity>().Any(whereExpression);

        public virtual Task<bool> ExistAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) =>  DbContext.Set<TEntity>().AnyAsync(whereExpression, cancellationToken);

        public virtual TEntity? Fetch(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(whereExpression);

        public virtual TEntity? Fetch<TProperty>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false)
        {
            return ascending
                ? DbContext.Set<TEntity>().AsNoTracking().OrderBy(orderByExpression).FirstOrDefault(whereExpression)
                : DbContext.Set<TEntity>().AsNoTracking().OrderByDescending(orderByExpression).FirstOrDefault(whereExpression)
                ;
        }

        public virtual Task<TEntity?> FetchAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) => DbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(whereExpression, cancellationToken);

        public virtual Task<TEntity?> FetchAsync<TProperty>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>>? orderByExpression, bool ascending = false, CancellationToken cancellationToken = default)
        {
            if (orderByExpression == null)
                return DbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(whereExpression, cancellationToken);

            return ascending
                ? DbContext.Set<TEntity>().AsNoTracking().OrderBy(orderByExpression).FirstOrDefaultAsync(whereExpression, cancellationToken)
                : DbContext.Set<TEntity>().AsNoTracking().OrderByDescending(orderByExpression).FirstOrDefaultAsync(whereExpression, cancellationToken)
                ;
        }

        public virtual int Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return DbContext.SaveChanges();
        }

        public virtual int Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return DbContext.SaveChanges();
        }

        public virtual Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().Add(entity);
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual int Delete(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = DbContext.Set<TEntity>().Attach(entity);
            entry.State = EntityState.Deleted;
            return DbContext.SaveChanges();
        }

        public virtual int Delete(params object[] keyValues)
        {
            var entity = DbContext.Find<TEntity>(keyValues);
            if (null == entity)
            {
                return 0;
            }
            DbContext.Set<TEntity>().Remove(entity);
            return DbContext.SaveChanges();
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> whereExpression)
        {
            DbContext.Set<TEntity>().RemoveRange(DbContext.Set<TEntity>().Where(whereExpression));
            return DbContext.SaveChanges();
        }

        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().RemoveRange(DbContext.Set<TEntity>().Where(whereExpression));
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> DeleteAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            var entity = DbContext.Find<TEntity>(keyValues);
            if (null == entity)
            {
                return 0;
            }
            DbContext.Set<TEntity>().Remove(entity);
            return await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = DbContext.Set<TEntity>().Attach(entity);
            entry.State = EntityState.Deleted;
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().AsNoTracking()
                .Where(whereExpression).ToList();

        public virtual List<TEntity> Select<TProperty>(int count, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false)
        {
            var query = DbContext.Set<TEntity>().AsNoTracking().Where(whereExpression);
            if (ascending)
            {
                query = query.OrderBy(orderByExpression);
            }
            else
            {
                query = query.OrderByDescending(orderByExpression);
            }
            return query.Take(count).ToList();
        }

        public virtual Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) => DbContext.Set<TEntity>().AsNoTracking().Where(whereExpression).ToListAsync(cancellationToken);

        public virtual Task<List<TEntity>> SelectAsync<TProperty>(int count, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false, CancellationToken cancellationToken = default)
        {
            var query = DbContext.Set<TEntity>().AsNoTracking().Where(whereExpression);
            if (ascending)
            {
                query = query.OrderBy(orderByExpression);
            }
            else
            {
                query = query.OrderByDescending(orderByExpression);
            }
            return query.Take(count).ToListAsync(cancellationToken);
        }

    }
}
