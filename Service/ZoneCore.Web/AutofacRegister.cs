using Autofac;
using Autofac.Extensions.DependencyInjection;
using ZoneCore.Repository;
using ZoneCore.Service;

namespace ZoneCore.Web
{
    public class AutofacRegister
    {
        public static void Load(ConfigureHostBuilder host)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            // 讓 Module 自動載入進來
            host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ServiceModule()));
            host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RepositoryModule()));
        }
    }
}
