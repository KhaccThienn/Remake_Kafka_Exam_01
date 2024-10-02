namespace Kafka_Exam_01.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ProductMemory           _inMem;

        public ProductService( ILogger<ProductService> logger, ProductMemory inMem)
        {
            _logger          = logger;
            _inMem           = inMem;
        }

        public List<TableProduct> GetProducts()
        {
            List<TableProduct> productList = new List<TableProduct>();
            try
            {
                productList = _inMem.Memory.Values.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            return productList;
        }
    }
}
