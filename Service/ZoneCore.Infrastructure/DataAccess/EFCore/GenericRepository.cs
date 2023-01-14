using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using static Dapper.SqlMapper;
namespace ZoneCore.Infra.DataAccess.EFCore
{
    public class GenericRepository<TDbContext, TEntity> : GenericEFExecute<TDbContext> where TDbContext : DbContext
            where TEntity : class
    {
        internal readonly TDbContext dbContext;

        public GenericRepository(TDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// 單數新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync<TEntity>(entity, cancellationToken);
        }

        /// <summary>
        /// 複數新增
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync<TEntity>(entities, cancellationToken);
        }

        /// <summary>
        /// 指定欄位更新方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            return base.UpdateAsync<TEntity>(entity, properties);
        }

        /// <summary>
        /// 單數刪除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync<TEntity>(entity, cancellationToken);
        }

        /// <summary>
        /// 複數刪除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync<TEntity>(whereExpression, cancellationToken);
        }

        /// <summary>
        /// 取消 EF 實體追蹤
        /// </summary>
        /// <param name="entity"></param>
        public void ClearTrack(TEntity entity)
        {
            base.ClearTrack<TEntity>(entity);
        }

        /// <summary>
        /// 條件取得列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression)
        {
            return base.Select<TEntity>(whereExpression);
        }
    }
}
