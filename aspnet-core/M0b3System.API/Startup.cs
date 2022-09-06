using M0b3System.API.Common.Auth;
using M0b3System.API.Common.Instance;
using M0b3System.Infrastructure.Common;
using M0b3System.Service;
using M0b3System.Service.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Encodings.Web;

namespace M0b3System.API
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAspNetUser, AspNetUser>();

            // Add Controller And SetJsonFormat 1.依照原類型回傳 2.自定義轉碼 3.統一化日期格式
            services.AddControllers()
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.PropertyNamingPolicy = null;
                    option.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                    option.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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


            // Add Jwt Config 
            services.Configure<JwtSecret>(configuration.GetSection("JwtSecret"));
            JwtSecret jwtSecret = configuration.GetSection("JwtSecret").Get<JwtSecret>();

            // Add AddAuthenticate (Jwt)
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // AddJwtBearer TokenValidation And Events
            .AddJwtBearer(option =>
            {
                //Jwt 要驗證甚麼
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSecret.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSecret.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret.Key)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(600),
                    RequireExpirationTime = true
                };

                option.Events = new JwtBearerEvents
                {
                    OnTokenValidated = JwtExtend.CusJwtOnTokenValidated()
                };
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                //Endpoints 全局驗證
                endpoints.MapControllers().RequireAuthorization(); ;
            });
        }
    }
}
