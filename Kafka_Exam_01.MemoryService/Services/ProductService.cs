namespace Kafka_Exam_01.MemoryService.Services
{
    public class ProductService : IProductService
    {
        private readonly IKafkaProducerManager _producerManager;
        private readonly ILogger<ProductService> _logger;
        private readonly ProductMemory _inMem;

        public ProductService(IKafkaProducerManager producerManager, ILogger<ProductService> logger, ProductMemory inMem)
        {
            _producerManager = producerManager;
            _logger = logger;
            _inMem = inMem;
        }

        public TableProduct InsertProduct(TableProduct p)
        {
            try
            {
                lock (_inMem.Memory)
                {
                    _inMem.Memory[p.Id.ToString()] = p;
                }

                var kafkaProducer = _producerManager.GetProducer<string, string>("1");
                var message = new Message<string, string>
                {
                    Value = JsonSerializer.Serialize(p),
                    Headers = new Headers
                    {
                        { "eventname", Encoding.UTF8.GetBytes("InsertProduct") },
                    }
                };

                kafkaProducer.Produce(message);
                return p;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public TableProduct UpdateQuantity(string key, decimal productId, decimal quantity, bool increase)
        {
            lock (_inMem.Memory)
            {
                if (_inMem.Memory.TryGetValue(key, out var p))
                {
                    p.Quantity = increase ? p.Quantity + quantity : (p.Quantity >= quantity ? p.Quantity - quantity : p.Quantity);

                    if (p.Quantity < 0)
                    {
                        _logger.LogError("Cannot Update Quantity");
                        return null;
                    }

                    var prod = new UpdateQuantityDTO
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Increase = increase
                    };

                    var kafkaProducer = _producerManager.GetProducer<string, string>("1");
                    var message = new Message<string, string>
                    {
                        Value = JsonSerializer.Serialize(prod),
                        Headers = new Headers
                        {
                            { "eventname", Encoding.UTF8.GetBytes("UpdateQuantity") },
                        }
                    };

                    kafkaProducer.Produce(message);
                    return p;
                }

                _logger.LogError("ID Not Found");
                return null;
            }
        }

        public TableProduct UpdatePrice(string key, decimal productId, decimal price)
        {
            lock (_inMem.Memory)
            {
                if (_inMem.Memory.TryGetValue(key, out var p))
                {
                    if (price > 0)
                    {
                        p.Price = price;

                        var prod = new UpdatePriceDTO
                        {
                            ProductId = productId,
                            Price = price
                        };

                        var kafkaProducer = _producerManager.GetProducer<string, string>("1");
                        var message = new Message<string, string>
                        {
                            Value = JsonSerializer.Serialize(prod),
                            Headers = new Headers
                            {
                                { "eventname", Encoding.UTF8.GetBytes("UpdatePrice") },
                            }
                        };

                        kafkaProducer.Produce(message);
                        return p;
                    }

                    _logger.LogError("Price must be greater than 0");
                }
                else
                {
                    _logger.LogError("Not Found Item in Memory");
                }

                return null;
            }
        }
    }
}
