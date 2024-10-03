namespace Kafka_Exam_01.OracleService.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomKafkaMessageBus(this IHost host)
        {
            host.UseKafkaMessageBus(mess =>
            {
                mess.RunConsumerAsync("0");
                mess.RunConsumerAsync("1");
            });
        }
    }
}
