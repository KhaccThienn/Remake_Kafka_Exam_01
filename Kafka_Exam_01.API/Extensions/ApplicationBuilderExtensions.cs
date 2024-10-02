namespace Kafka_Exam_01.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void LoadProductMemoryData(this WebApplication app)
        {
            app.LoadDataToMemory<ProductMemory, ApplicationDbContext>((productInMe, dbContext) =>
            {
                new ProductMemorySeedAsync().SeedAsync(productInMe, dbContext).Wait();
            });
        }
    }
}
