namespace Kafka_Exam_01.Infrastructure.DTOs
{
    public class UpdateQuantityDTO
    {
        public decimal  ProductId { get; set; }
        public decimal  Quantity  { get; set; }
        public bool     Increase  { get; set; }
    }
}
