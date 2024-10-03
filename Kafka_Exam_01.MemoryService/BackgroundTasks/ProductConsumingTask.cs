using Kafka_Exam_01.MemoryService.Commands.Handlers;

namespace Kafka_Exam_01.MemoryService.BackgroundTasks
{
    public class ProductConsumingTask : IConsumingTask<string, string>
    {
        private readonly ILogger<ProductConsumingTask>          _logger;
        private readonly ICommandHandler<InsertProductCommand>  _insertProductCommandHandler;
        private readonly ICommandHandler<UpdatePriceCommand>    _updatePriceProductCommandHandler;
        private readonly ICommandHandler<UpdateQuantityCommand> _updateQuantityProductCommandHandler;

        public ProductConsumingTask(
            ILogger<ProductConsumingTask>          logger,
            ICommandHandler<InsertProductCommand>  insertProductCommandHandler,
            ICommandHandler<UpdatePriceCommand>    updatePriceProductCommandHandler,
            ICommandHandler<UpdateQuantityCommand> updateQuantityProductCommandHandler
            )
        {
            _logger                              = logger;
            _insertProductCommandHandler         = insertProductCommandHandler;
            _updatePriceProductCommandHandler    = updatePriceProductCommandHandler;
            _updateQuantityProductCommandHandler = updateQuantityProductCommandHandler;
        }

        public async Task ExecuteAsync(ConsumeResult<string, string> result)
        {
            // Get eventname from message header
            var productEvent = "";
            foreach (var header in result.Message.Headers)
            {
                productEvent = Encoding.UTF8.GetString(header.GetValueBytes());
            }
            _logger.LogInformation(
                $"Consuming message from topic: {result.Topic}, Partition: {result.Partition}, Offset: {result.Offset}, Key: {result.Message.Key}");

            switch (productEvent)
            {
                case "InsertProduct":
                    var product = JsonSerializer.Deserialize<TableProduct>(result.Message.Value);

                    Guid newGuid = Guid.NewGuid();
                    int id       = Math.Abs(newGuid.GetHashCode());
                    product.Id   = id;

                    _logger.LogInformation("Inserting new product: {@Product}", product);

                    _insertProductCommandHandler.Handle(new InsertProductCommand(product.Id, product.Name, product.Price, product.Quantity));
                    
                    break;

                case "UpdateQuantity":

                    _logger.LogInformation(result.Message.Key);
                    _logger.LogInformation(result.Message.Value);

                    var prod = JsonSerializer.Deserialize<UpdateQuantityDTO>(result.Message.Value);
                    var key  = result.Message.Key;

                    _logger.LogInformation("Updating quantity for product ID: {ProductId}, New Quantity: {Quantity}, Increase: {Increase}",
                        prod.ProductId, prod.Quantity, prod.Increase);

                    _updateQuantityProductCommandHandler.Handle(new UpdateQuantityCommand(key, prod.ProductId, prod.Quantity, prod.Increase));

                    break;

                case "UpdatePrice":
                    var p = JsonSerializer.Deserialize<UpdatePriceDTO>(result.Message.Value);
                    var k = result.Message.Key;

                    _logger.LogInformation("Updating price for product ID: {ProductId}, New Price: {Price}", p.ProductId, p.Price);
                    _updatePriceProductCommandHandler.Handle(new UpdatePriceCommand(k, p.ProductId, p.Price));

                    break;

                default:
                    _logger.LogWarning("Received unknown event: {Event}", productEvent);
                    break;
            }
        }
    }
}
