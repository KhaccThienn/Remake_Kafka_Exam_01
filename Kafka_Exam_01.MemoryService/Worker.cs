namespace Kafka_Exam_01.MemoryService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker>                        _logger;
        private readonly ICommandHandler<InsertProductCommand>  _insertProductCommandHandler;
        private readonly ICommandHandler<UpdatePriceCommand>    _updatePriceProductCommandHandler;
        private readonly ICommandHandler<UpdateQuantityCommand> _updateQuantityProductCommandHandler;
        public Worker(
            ILogger<Worker>                                     logger,
            ICommandHandler<InsertProductCommand>               insertProductCommandHandler,
            ICommandHandler<UpdatePriceCommand>                 updatePriceProductCommandHandler,
            ICommandHandler<UpdateQuantityCommand>              updateQuantityProductCommandHandler
            )
        {
            _logger                              = logger;
            _insertProductCommandHandler         = insertProductCommandHandler;
            _updatePriceProductCommandHandler    = updatePriceProductCommandHandler;
            _updateQuantityProductCommandHandler = updateQuantityProductCommandHandler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                GroupId          = "0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset  = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("Consumer started. Press Ctrl+C to exit.");

                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume();
                        await Console.Out.WriteLineAsync(consumeResult.Message.Key.ToString());
                        Console.WriteLine($"Received message: {consumeResult.Message.Value} at {consumeResult.TopicPartitionOffset}");
                    }
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error occurred: {e.Error.Reason}");
                }
            }
        }
    }
}
