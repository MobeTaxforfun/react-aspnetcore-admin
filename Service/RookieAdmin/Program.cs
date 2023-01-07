using Autofac;
using Autofac.Extensions.DependencyInjection;
using RookieAdmin.Common.Middlewares;

namespace RookieAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 註冊 Autofac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacRegister()));

            // Configure Configuration
            ConfigurationManager configuration = builder.Configuration;
            // Configure Service
            Startup.ConfigureServices(builder.Services, configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Cros
            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));
            // 先驗狗牌
            app.UseAuthentication();
            // 在看使用者
            app.UseLoadUser();
            // 最後授權
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}