namespace ZoneCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            // Add services to the container.
            ConfigurationManager configuration = builder.Configuration;
            // �򥻪`�J
            Startup.ConfigureServices(builder.Services, configuration);
            // AutoFact �`�J
            AutofacRegister.Load(builder.Host);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // ���ϥ� Routing
            // app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();

            // ���ϥ� Routing
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