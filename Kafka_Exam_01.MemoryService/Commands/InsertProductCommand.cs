﻿namespace Kafka_Exam_01.MemoryService.Commands
{
    public record InsertProductCommand(decimal id, string Name, decimal Price, decimal Quantity) : ICommand;
}
