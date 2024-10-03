namespace Kafka_Exam_01.OracleService.Commands.Handlers
{
    public class UpdateProductPriceCommandHandler : ICommandHandler<UpdatePriceCommand>
    {
        private readonly IServiceProvider _service;
        public UpdateProductPriceCommandHandler(IServiceProvider service)
        {
            _service = service;
        }
        public async Task HandleAsync(UpdatePriceCommand command)
        {
            using var scope = _service.CreateScope();

            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            await productService.UpdatePrice(command.ProductId, command.Price);
        }
    }
}
