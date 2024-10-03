using Kafka_Exam_01.Infrastructure.Domain;

namespace Kafka_Exam_01.OracleService.Commands.Handlers
{
    public class InsertProductCommandHandler : ICommandHandler<InsertProductCommand>
    {
        private readonly IServiceProvider _service;
        public InsertProductCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public async Task HandleAsync(InsertProductCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            // Use productService here
            var product = new TableProduct
            {
                Id       = command.id,
                Name     = command.Name,
                Price    = command.Price,
                Quantity = command.Quantity
            };
            await productService.InsertProduct(product);

        }
    }
}
