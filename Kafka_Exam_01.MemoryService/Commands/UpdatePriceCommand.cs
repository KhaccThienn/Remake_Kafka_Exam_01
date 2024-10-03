namespace Kafka_Exam_01.MemoryService.Interfaces.Commands
{
    public record UpdatePriceCommand(string Key, decimal ProductId, decimal Price) : ICommand;
}
