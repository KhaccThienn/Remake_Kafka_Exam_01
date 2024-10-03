namespace Kafka_Exam_01.MemoryService.Interfaces.Commands
{
    public record UpdateQuantityCommand(string Key, decimal ProductId, decimal Quantity, bool Increase) : ICommand;
}
