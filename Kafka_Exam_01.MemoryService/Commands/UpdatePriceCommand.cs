namespace Kafka_Exam_01.MemoryService.Commands
{
    public record UpdatePriceCommand(string Key, decimal ProductId, decimal Price) : ICommand;
}
