namespace ZoneCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            // Add services to the container.
            ConfigurationManager configuration = builder.Configuration;
            // 基本注入
            Startup.ConfigureServices(builder.Services, configuration);
            // AutoFact 注入
            AutofacRegister.Load(builder.Host);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // 不使用 Routing
            // app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();

            // 不使用 Routing
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}"
            //    );
            //});

            app.Run();
        }
    }
}