namespace Kafka_Exam_01.OracleService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductProcessingServices(this IServiceCollection services, IConfiguration configuration, AppSetting appSetting)
        {

            services.AddDbContextServices(configuration)
                .AddScopedServices()
                .AddCommandHandlers()
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

        public static IServiceCollection AddScopedServices(this IServiceCollection services )
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }

        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<InsertProductCommand>,  InsertProductCommandHandler>();
            services.AddTransient<ICommandHandler<UpdatePriceCommand>,    UpdateProductPriceCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateQuantityCommand>, UpdateProductQuantityCommandHandler>();

            return services;
        }

        public static IServiceCollection AddKafkaServices(this IServiceCollection services, AppSetting appSetting)
        {
            services.AddKafkaProducers(producerBuilder =>
            {
                producerBuilder.AddProducer(appSetting.GetProducerSetting("1"));
            });

            services.AddKafkaConsumers(builder =>
            {
                builder.AddConsumer<ProductPersistanceConsumingTask>(appSetting.GetConsumerSetting("1"));
            });

            return services;
        }

        public static IServiceCollection AddMiscellaneousServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            return services;
        }
    }
}
