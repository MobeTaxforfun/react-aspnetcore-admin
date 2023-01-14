using Autofac;

namespace ZoneCore.Service
{
    public class ServiceModule : Module
    {
        /// <summary>
        /// Autofac 自動註冊介面
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // InstancePerDependency 類似於 AddTransient 每次呼叫都回傳一個新的實體, Autofac 預設為 InstancePerDependency
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency();

            base.Load(builder);
        }
    }
}
