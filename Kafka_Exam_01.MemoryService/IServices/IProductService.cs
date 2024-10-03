namespace Kafka_Exam_01.MemoryService.IServices
{
    public interface IProductService
    {
        TableProduct InsertProduct(TableProduct p);
        TableProduct UpdateQuantity(string key, decimal productId, decimal quantity, bool increase);
        TableProduct UpdatePrice(string key, decimal productId, decimal price);
    }
}
