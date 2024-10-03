namespace Kafka_Exam_01.Infrastructure.InMemories
{
    public class ProductMemory
    {
        private readonly Dictionary<string, TableProduct>   _memory = new Dictionary<string, TableProduct>();
        private readonly object                             _lock   = new object();

        public Dictionary<string, TableProduct> Memory
        {
            get
            {
                lock (_lock)
                {
                    return _memory;
                }
            }
        }

    }
}
