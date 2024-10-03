namespace Kafka_Exam_01.MemoryService.Commands.Handlers
{
    public class UpdateProductPriceCommandHandler : ICommandHandler<UpdatePriceCommand>
    {
        private readonly IServiceProvider _service;
        public UpdateProductPriceCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public void Handle(UpdatePriceCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            productService.UpdatePrice(command.Key, command.ProductId, command.Price);
        }
    }
}
