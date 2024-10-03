namespace Kafka_Exam_01.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDerivateTradeServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextServices(configuration)
                .AddSingletonMemoryServices()
                .AddScopedServices()
                .AddMiscellaneousServices();
            return services;
        }

        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseOracle(configuration.GetConnectionString("OrclDB"));
            });

            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddMiscellaneousServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            return services;
        }
    }
}
