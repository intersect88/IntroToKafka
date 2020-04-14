using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Kafka.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092"};

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var deliveryResult = await producer.ProduceAsync("demo-topic", new Message<Null, string> { Value = $"DemoMessage '{i}'" });
                        Console.WriteLine($"Published message to '{deliveryResult.TopicPartitionOffset}'");
                    }
                    
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Error publishing message: {e.Error.Reason}");
                }
            }
        }
    }
}
