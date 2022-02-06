using DBManager.ORM;
using DBManager.QueryManager;
using Microsoft.OpenApi.Models;

namespace DBProject_Team11
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            AddClassesToIoC(services);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "db-project", Version = "v1"});
            });
        }

        private static void AddClassesToIoC(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<DbProjectContext>();
            services.AddSingleton<ISearch, Search>();
            services.AddSingleton<IInsert, Insert>();
        }
        
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "db-project v1"));
            }


            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}