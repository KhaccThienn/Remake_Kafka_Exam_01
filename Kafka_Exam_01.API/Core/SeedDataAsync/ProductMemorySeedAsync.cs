namespace Kafka_Exam_01.API.Core.SeedDataAsync
{
    public class ProductMemorySeedAsync
    {
        public async Task SeedAsync(ProductMemory memory, ApplicationDbContext dbContext)
        {
            var products = await dbContext.TableProducts.ToListAsync();
            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    memory.Memory.Add(product.Id.ToString(), product);
                }
            }
        }
    }
}
