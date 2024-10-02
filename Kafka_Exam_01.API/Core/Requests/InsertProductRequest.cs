namespace Kafka_Exam_01.API.Core.Requests
{
    public class InsertProductRequest
    {
        public string    Name       { get; set; }
        public decimal   Price      { get; set; }
        public decimal   Quantity   { get; set; }
    }
}
