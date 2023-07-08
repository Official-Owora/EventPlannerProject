using EventPlannerProject.Application.Common;
using EventPlannerProject.Persistence.Common;
using EventPlannerProject.ServiceContract.Interfaces;
using EventPlannerProject.ServiceRepository.Service;
using LoggerService;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerProject.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        //Configuration of CORS for giving access right to applications from other domains
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            });
        }
        //Configuration of IIS Integration for accepting requests from remote client computers and returns the appropriate response
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        //Configuration of the Logger Service
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //Congiguration of the RepositoryManager
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        //Configuration of the Service Manager
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        //Configuration of DbContext and SQL Connection
        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<RepositoryContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    }
}
