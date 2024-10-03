namespace Kafka_Exam_01.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductMemory _inMem;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ProductMemory inMem, ILogger<ProductService> logger)
        {
            _inMem = inMem;
            _logger = logger;
        }

        public List<TableProduct> GetProducts()
        {
            try
            {
                lock (_inMem.Memory)
                {
                    return _inMem.Memory.Values.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
