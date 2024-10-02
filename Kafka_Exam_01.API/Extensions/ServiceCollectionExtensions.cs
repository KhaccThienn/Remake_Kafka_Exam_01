namespace Kafka_Exam_01.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDerivateTradeServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextServices(configuration)
                .AddSingletonServices()
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

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<ProductMemory>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductProducer, ProductProducer>();

            return services;
        }

        public static IServiceCollection AddMiscellaneousServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            return services;
        }
    }
}
