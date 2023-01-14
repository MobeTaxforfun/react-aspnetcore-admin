using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ZoneCore.Common.Profiles
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCommonMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
