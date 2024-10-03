
namespace Kafka_Exam_01.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureRegisterService(this IServiceCollection services, IConfiguration configuration, AppSetting appSetting)
        {

            services.AddDbContextServices(configuration)
                .AddSingletonServices()
                .AddKafkaServices(appSetting);
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

        public static IServiceCollection AddKafkaServices(this IServiceCollection services, AppSetting appSetting)
        {
            services.AddKafkaProducers(producerBuilder =>
            {
                producerBuilder.AddProducer(appSetting.GetProducerSetting("1"));
            });

            return services;
        }

        public static IServiceCollection AddSingletonMemoryServices(this IServiceCollection services)
        {
            services.AddSingleton<ProductMemory>();
            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<ProductMemory>();
            services.AddSingleton<IProductProducer, ProductProducer>();
            return services;
        }
    }
}
