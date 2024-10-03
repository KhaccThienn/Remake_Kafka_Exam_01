namespace Kafka_Exam_01.MemoryService.Interfaces.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
    }
}
