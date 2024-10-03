
namespace Kafka_Exam_01.OracleService.Commands
{
    public record UpdatePriceCommand( decimal ProductId, decimal Price) : ICommand;
}
