namespace Kafka_Exam_01.API.Core.Requests
{
    public class UpdatePriceRequest
    {
        public string       Key         { get; set; }
        public decimal      ProductId   { get; set; }
        public decimal      Price       { get; set; }
    }
}
