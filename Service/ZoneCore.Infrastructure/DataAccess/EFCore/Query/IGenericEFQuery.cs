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
    public interface IGenericEFQuery
    {
        int Count<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class;
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default) where TEntity : class;
        TEntity? Fetch<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;
        Task<TEntity?> FetchAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;
        Task<List<TEntity>> ListedAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> ListedAsync<TEntity>(Expression<Func<TEntity, bool>>? condition, CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> ListedAsync<TEntity>(Expression<Func<TEntity, bool>>? condition, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby, CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> ListedAsync<TEntity>(Expression<Func<TEntity, bool>>? condition, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby, CancellationToken cancellationToken = default) where TEntity : class;
        Task<PaginateModel<TEntity>> PagedAsync<TEntity>(int page, int itemsPerPage, Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby = null) where TEntity : class;
    }
}
