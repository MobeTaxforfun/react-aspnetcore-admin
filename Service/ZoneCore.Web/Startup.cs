using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZoneCore.Common.Profiles;
using ZoneCore.Infra.DataAccess;
using ZoneCore.Infra.DataAccess.EFCore;
using ZoneCore.Infra.DataAccess.EFCore.Context;
using ZoneCore.Models.Entity;

namespace ZoneCore.Web
{
    public class Startup
    {
        public const string SystemName = ".Zone";

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddGenericRepository<SystemDbContext>();
            services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // AutoMapper 先進來
            services.AddCommonMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
