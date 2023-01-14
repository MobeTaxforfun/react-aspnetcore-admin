using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ZoneCore.Infra.DataAccess.Dapper
{
    public static class DapperExtension
    {
        /// <summary>
        /// DapperExecute 擴展
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static int DapperExecute(this DatabaseFacade database, string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.Execute(sql, param, trn, commandTimeout, commandType);
        }

        /// <summary>
        /// DapperExecuteAsync 非同步擴展
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<int> DapperExecuteAsync(this DatabaseFacade database, string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.ExecuteAsync(sql, param, trn, commandTimeout, commandType);
        }

        /// <summary>
        /// DapperQuery 擴展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<T> DapperQuery<T>(this DatabaseFacade database, string sql, object? param, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.Query<T>(sql, param, trn, buffered, commandTimeout, commandType);
        }

        /// <summary>
        /// DapperQueryAsync 擴展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> DapperQueryAsync<T>(this DatabaseFacade database, string sql, object? param, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.QueryAsync<T>(sql, param, trn, commandTimeout, commandType);
        }

        /// <summary>
        /// DapperQueryFirstOrDefault 擴展
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static T DapperQueryFirstOrDefault<T>(this DatabaseFacade database, string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.QueryFirstOrDefault<T>(sql, param, trn, commandTimeout, commandType);
        }

        /// <summary>
        /// DapperQueryFirstOrDefaultAsync 擴展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<T> DapperQueryFirstOrDefaultAsync<T>(this DatabaseFacade database, string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var connection = database.GetDbConnection();
            IDbTransaction trn = database.CurrentTransaction?.GetDbTransaction()!;
            return connection.QueryFirstOrDefaultAsync<T>(sql, param, trn, commandTimeout, commandType);
        }
    }
}
