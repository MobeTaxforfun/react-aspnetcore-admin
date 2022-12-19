using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RookieAdmin.Common.AppAuthorize;
using RookieAdmin.Common.Instances;
using RookieAdmin.Models.Entity;
using RookieAdmin.Repository.Implement;
using RookieAdmin.Repository.Interface;
using RookieAdmin.Service.Implement;
using RookieAdmin.Service.Interface;
using System.Text;

namespace RookieAdmin
{
    public class Startup
    {
        public const string SystemName = ".RookieAdmin";

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                // 定義 Swagger 驗證介面
                options.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            Name = "系統認證 - Jwt Authorization",
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "Bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "JWT Authorization，請由登入API取得 Token 後再行登入。"
                        });
                // 定義 Swagger 驗證方法
                options.AddSecurityRequirement(
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] {}
                            }
                        });
            });

            // Add JWT
            services.AddSingleton<JwtSecurity>();
            // Add 授權
            services.AddAuthorization();
            // Add 驗證
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
                    options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 一般都會驗證 Issuer
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        // 通常不太需要驗證 Audience
                        ValidateAudience = false,
                        //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫
                        // 一般我們都會驗證 Token 的有效期間
                        ValidateLifetime = true,
                        // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                        ValidateIssuerSigningKey = false,
                        // 從 IConfiguration 取得
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SignKey"]))
                    };
                });

            // Add  自訂授權
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            // Add HttpContext 上下文
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            // Add 現在使用者
            services.AddScoped<IAspNetUser, AspNetUser>();
            // Add AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // 資料相關

            // Add db Service
            services.AddDbContext<RookieAdminDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });


            // 先注入在這邊之後移到 AutoFac ( Service, Repository 已經移至 Autofac )          
        }
    }
}
