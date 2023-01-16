using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.Model;
using static Dapper.SqlMapper;

namespace ZoneCore.Infra.DataAccess.EFCore.Query
{
   
    public class GenericEFQuery<TDbContext> : IGenericEFQuery where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public GenericEFQuery(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 查詢單筆
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity? Fetch<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class => _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(whereExpression);

        /// <summary>
        /// 查詢單筆
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public Task<TEntity?> FetchAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class => _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(whereExpression);

        /// <summary>
        /// 查詢表單
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListedAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : class
        {
            return ListedAsync<TEntity>(null, cancellationToken);
        }

        /// <summary>
        /// 查詢表單
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="condition"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListedAsync<TEntity>(
           Expression<Func<TEntity, bool>>? condition,
           CancellationToken cancellationToken = default)
              where TEntity : class
        {
            return ListedAsync(condition: condition, orderby: null, cancellationToken);
        }


        /// <summary>
        /// 查詢表單
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="condition"></param>
        /// <param name="includes"></param>
        /// <param name="orderby"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListedAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby,
            CancellationToken cancellationToken = default)
               where TEntity : class
        {
            return ListedAsync(condition: condition, includes: null, orderby: orderby, cancellationToken);
        }

        /// <summary>
        /// 查詢表單
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListedAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby,
            CancellationToken cancellationToken = default)
            where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            return query.ToListAsync(cancellationToken);
        }

        /// <summary>
        ///  計算數量
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Count<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class => _dbContext.Set<TEntity>().Count(condition);

        /// <summary>
        /// 計算數量
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default) where TEntity : class => _dbContext.Set<TEntity>().CountAsync(condition, cancellationToken);

        /// <summary>
        /// 分頁查詢
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="condition"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public async Task<PaginateModel<TEntity>> PagedAsync<TEntity>(
            int page,
            int itemsPerPage,
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby = null) where TEntity : class
        {

            var max = await _dbContext.Set<TEntity>().AsNoTracking().CountAsync(condition);

            if (max == 0)
            {
                return new PaginateModel<TEntity>
                {
                    Page = page,
                    ItemsPerPage = itemsPerPage,
                    Max = max,
                    Result = null
                };
            }

            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(condition);

            if (orderby != null)
            {
                query = orderby(query);
            }

            var data = await query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();

            return new PaginateModel<TEntity>
            {
                Page = page,
                ItemsPerPage = itemsPerPage,
                Max = max,
                Result = data
            };
        }
    }
}
