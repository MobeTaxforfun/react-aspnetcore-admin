using M0b3System.Infrastructure.Common;
using M0b3System.Service;
using M0b3System.Service.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Encodings.Web;

namespace M0b3System.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add Configuration 
            ConfigurationManager configuration = builder.Configuration;
            var startup = new Startup(configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            // Build Middleware
            startup.Configure(app, builder.Environment);
            app.Run();
        }
    }
}