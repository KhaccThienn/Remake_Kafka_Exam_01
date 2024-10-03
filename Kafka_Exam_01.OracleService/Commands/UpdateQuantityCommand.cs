namespace Kafka_Exam_01.OracleService.Commands
{
    public record UpdateQuantityCommand(decimal ProductId, decimal Quantity, bool Increase) : ICommand;
}
