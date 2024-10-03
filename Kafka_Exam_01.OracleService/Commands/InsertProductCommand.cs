namespace Kafka_Exam_01.OracleService.Commands
{
    public record InsertProductCommand(decimal id, string Name, decimal Price, decimal Quantity) : ICommand;
}
