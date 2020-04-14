using System;
using Confluent.Kafka;

class Program
{
    public static void Main(string[] args)
    {
        var conf = new ConsumerConfig
        {
            GroupId = "demo-consumer-group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(conf).Build())
        {
            consumer.Subscribe("demo-topic");

            var readingMessage = true;
            try
            {
                while (readingMessage)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(10000);
                        if (consumeResult == null)
                        {
                            Console.WriteLine("There are no messages in topic");
                            readingMessage = false;
                        }
                        else
                        {
                            Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");
                        }
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {

                consumer.Close();
            }
        }
    }
}