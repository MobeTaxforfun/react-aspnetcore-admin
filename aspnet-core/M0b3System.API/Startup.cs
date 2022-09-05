using M0b3System.Infrastructure.Common;
using M0b3System.Service;
using M0b3System.Service.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
            services.AddSwaggerGen();


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
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret.Key)),
                    ClockSkew = TimeSpan.Zero
                };

                option.Events = new JwtBearerEvents
                {

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

            app.UseAuthorization();

            //app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
