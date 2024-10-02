namespace Kafka_Exam_01.API.Core.InMemories
{
    public class ProductMemory
    {
        public Dictionary<string, TableProduct> Memory { get; set; }

        public ProductMemory()
        {
            Memory = new Dictionary<string, TableProduct>();
        }

    }
}
