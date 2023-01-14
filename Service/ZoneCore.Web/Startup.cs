using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZoneCore.Common.Profiles;
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
