using Autofac;

namespace RookieAdmin
{
    public class AutofacRegister : Module
    {
        /// <summary>
        /// 自動註冊介面
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // InstancePerDependency 類似於 AddTransient 每次呼叫都回傳一個新的實體, Autofac 預設為 InstancePerDependency

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                   .Where(c => c.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces().InstancePerDependency();

            base.Load(builder);
        }
    }
}
