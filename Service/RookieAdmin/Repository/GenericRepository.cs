using Microsoft.EntityFrameworkCore;
using RookieAdmin.Models.Model;
using System.Linq.Expressions;

namespace RookieAdmin.Repository
{
    public class GenericRepository<TDbContext, TEntity> : IGenericRepository<TDbContext, TEntity> where TDbContext : DbContext
          where TEntity : class
    {
        internal TDbContext DbContext { get; }

        public GenericRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Track 控制


        public void ClearTrack(TEntity entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Detached;
        }

        #endregion


        #region 新增的家

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 複數新增方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 非同步新增方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().Add(entity);
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 非同步複數新增方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public virtual Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region 刪除的家

        /// <summary>
        /// 刪除方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// 非同步刪除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// 條件式刪除
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> whereExpression)
        {
            DbContext.Set<TEntity>().RemoveRange(DbContext.Set<TEntity>().Where(whereExpression));
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 非同步條件式刪除
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().RemoveRange(DbContext.Set<TEntity>().Where(whereExpression));
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region 更新的家 這裡是地獄真難寫(╬☉д⊙)

        /// <summary>
        /// 更新方法(實體) 這個會把資料表裡面全部的資料更新小心
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 非同步更新方法(實體)  這個會把資料表裡面全部的資料更新小心
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 更新方法(部分) 這個是局部更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            var test = DbContext.Attach(entity);

            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    DbContext.Entry(entity).Property(property).IsModified = true;
                }
            }

            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 非同步更新方法(部分) 這個是局部更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {

            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            //標記更新
            DbContext.Attach(entity);
            //用反射更新
            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    DbContext.Entry(entity).Property(property).IsModified = true;
                }
            }

            return DbContext.SaveChangesAsync();
        }

        #endregion

        #region 查 ※ 沒寫 Order by 有點懶...  方法這邊都是取全部,資料量大的 order by 請在各自的 Repository 裡面擴增

        public virtual TEntity? Fetch(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(whereExpression);

        public virtual Task<TEntity?> FetchAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
           => DbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(whereExpression, cancellationToken);

        public virtual List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().AsNoTracking().Where(whereExpression).ToList();

        public virtual Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
            => DbContext.Set<TEntity>().AsNoTracking().Where(whereExpression).ToListAsync(cancellationToken);

        public virtual List<TEntity> Listed() => DbContext.Set<TEntity>().ToList();

        public virtual Task<List<TEntity>> ToListAsync() => DbContext.Set<TEntity>().ToListAsync();

        public virtual bool Exist(Expression<Func<TEntity, bool>> whereExpression) => DbContext.Set<TEntity>().Any(whereExpression);

        public virtual Task<bool> ExistAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default) => DbContext.Set<TEntity>().AnyAsync(whereExpression, cancellationToken);

        #endregion

        #region 分頁方法

        #endregion
    }
}
