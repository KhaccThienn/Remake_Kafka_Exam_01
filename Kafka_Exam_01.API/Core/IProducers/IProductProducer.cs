namespace Kafka_Exam_01.API.Core.IProducers
{
    public interface IProductProducer
    {
        Task ProduceInsertProductAsync(InsertProductRequest product);
        Task ProduceUpdateQuantityAsync(UpdateQuantityRequest request);
        Task ProduceUpdatePriceAsync(UpdatePriceRequest request);
    }
}
