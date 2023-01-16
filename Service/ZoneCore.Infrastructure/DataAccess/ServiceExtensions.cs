using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using ZoneCore.Infra.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ZoneCore.Infra.DataAccess
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// 注入共用的 TDbContext repository 
        /// </summary>
        /// <typeparam name="TDbContext">注入要生成 Repo 的 Dbcontext</typeparam>
        /// <param name="services"></param>
        /// <param name="lifetime">注入得生命週期(預設為 Scoped)</param>
        /// <returns >Retruns <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"> ServiceCollection 不可為空</exception>
        public static IServiceCollection AddGenericRepository<TDbContext>(
            this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TDbContext : DbContext
        {
            services.Add(new ServiceDescriptor(
            typeof(IRepository),
            serviceProvider =>
            {
                TDbContext dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
                return new GenericEFExecute<TDbContext>(dbContext);
            },
            lifetime));

            return services;
        }
    }
}
