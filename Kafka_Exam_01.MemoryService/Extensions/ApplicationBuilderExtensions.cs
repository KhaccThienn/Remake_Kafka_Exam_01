namespace Kafka_Exam_01.MemoryService.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //public static void LoadProductMemoryData(this IHost host)
        //{
        //    host.LoadDataToMemory<ProductMemory, ApplicationDbContext>((productInMe, dbContext) =>
        //    {
        //        new ProductMemorySeedAsync().SeedAsync(productInMe, dbContext).Wait();
        //    });
        //}

        public static void UseCustomKafkaMessageBus(this IHost host)
        {
            host.UseKafkaMessageBus(mess =>
            {
                mess.RunConsumerAsync("0");
                mess.RunConsumerAsync("1");
            });
        }
    }
}
