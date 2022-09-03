using M0b3System.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGenericRepository(
           this IServiceCollection services,
           ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            // NullException
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Exteinsions Add Service
            services.TryAdd(new ServiceDescriptor(typeof(IGenericEFRepository<,>), typeof(GenericEFRepository<,>), lifetime));        
            return services;
        }
    }
}
