using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.EFCore.Query;
using static Dapper.SqlMapper;

namespace ZoneCore.Infra.DataAccess.EFCore.Context
{
    public class GenericEFExecute<TDbContext> : GenericEFQuery<TDbContext>, IRepository
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public GenericEFExecute(TDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #region 新增的家

        /// <summary>
        /// 單數新增
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();

        }

        /// <summary>
        /// 複數新增
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 單數新增 (NoTrack)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<int> InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
            var count = _dbContext.SaveChangesAsync(cancellationToken);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return count;
        }

        /// <summary>
        /// 複數新增 (NoTrack)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<int> InsertAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            var count = _dbContext.SaveChangesAsync(cancellationToken);
            _dbContext.Entry(entities).State = EntityState.Detached;
            return count;
        }

        #endregion

        #region 更新的家

        public int Update<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            _dbContext.Attach(entity);

            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    _dbContext.Entry(entity).Property(property).IsModified = true;
                }
            }
            var count = _dbContext.SaveChanges();
            _dbContext.Entry(entity).State = EntityState.Detached;
            return count;
        }

        /// <summary>
        /// 指定欄位更新方法 (NoTrack)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            _dbContext.Attach(entity);

            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    _dbContext.Entry(entity).Property(property).IsModified = true;
                }
            }
            var count = _dbContext.SaveChangesAsync();
            _dbContext.Entry(entity).State = EntityState.Detached;
            return count;
        }

        #endregion

        #region 刪除的家

        public Task<int> DeleteAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = _dbContext.Set<TEntity>().Attach(entity);
            entry.State = EntityState.Deleted;
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 條件式刪除
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().RemoveRange(_dbContext.Set<TEntity>().Where(whereExpression));
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Track控制

        /// <summary>
        /// 取消 EF 實體追蹤
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void ClearTrack<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        #endregion

    }
}
