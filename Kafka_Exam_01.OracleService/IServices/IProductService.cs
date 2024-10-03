namespace Kafka_Exam_01.OracleService.IServices
{
    public interface IProductService
    {
        Task<TableProduct> InsertProduct(TableProduct p);
        Task<TableProduct?> UpdateQuantity(decimal productId, decimal quantity, bool Increase);
        Task<TableProduct?> UpdatePrice(decimal productId, decimal price);
    }
}
