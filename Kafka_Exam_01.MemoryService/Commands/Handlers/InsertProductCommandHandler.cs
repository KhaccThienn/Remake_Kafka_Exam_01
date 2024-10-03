namespace Kafka_Exam_01.MemoryService.Commands.Handlers
{
    public class InsertProductCommandHandler : ICommandHandler<InsertProductCommand>
    {
        private readonly IServiceProvider _service;
        public InsertProductCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public void Handle(InsertProductCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            // Use productService here
            var product = new TableProduct
            {
                Id = command.id,
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity
            };
            productService.InsertProduct(product);

        }
    }
}
