namespace Kafka_Exam_01.OracleService.Commands.Handlers
{
    public class UpdateProductQuantityCommandHandler : ICommandHandler<UpdateQuantityCommand>
    {
        private readonly IServiceProvider _service;
        public UpdateProductQuantityCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public async Task HandleAsync(UpdateQuantityCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            await productService.UpdateQuantity(command.ProductId, command.Quantity, command.Increase);
        }
    }
}
