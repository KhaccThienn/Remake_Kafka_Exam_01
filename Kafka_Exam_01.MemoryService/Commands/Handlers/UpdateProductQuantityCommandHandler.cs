namespace Kafka_Exam_01.MemoryService.Commands.Handlers
{
    public class UpdateProductQuantityCommandHandler : ICommandHandler<UpdateQuantityCommand>
    {
        private readonly IServiceProvider _service;
        public UpdateProductQuantityCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public void Handle(UpdateQuantityCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            productService.UpdateQuantity(command.Key, command.ProductId, command.Quantity, command.Increase);
        }
    }
}
