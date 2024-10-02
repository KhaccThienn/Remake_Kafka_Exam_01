namespace Kafka_Exam_01.API.Core.Requests
{
    public class UpdateQuantityRequest
    {
        public string       Key         { get; set; }
        public decimal      ProductId   { get; set; }
        public decimal      Quantity    { get; set; }
        public bool         Increase    { get; set; }
    }
}
