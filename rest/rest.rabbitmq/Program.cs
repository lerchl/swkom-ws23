using EasyNetQ;
using EasyNetQ.Topology;
namespace rest.rabbitmq
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            // var publisher = new Publisher();
            // publisher.SendMessage("Hello, World!");
            const string RabbitMqConnectionString = "host=localhost;username=rabbitmq;password=rabbitmq";
            const string ExchangeName = "document_exchange";
            const string QueueName = "document_queue";
            const string RoutingKey = "document_routing_key";

            // Create an instance of the message bus
            using (var bus = RabbitHutch.CreateBus(RabbitMqConnectionString))
            {
                var advancedBus = bus.Advanced;

                // Declare the exchange
                var exchange = advancedBus.ExchangeDeclare(ExchangeName, ExchangeType.Direct);

                // Declare the queue
                var queue = advancedBus.QueueDeclare(QueueName);

                // Bind the queue to the exchange
                advancedBus.Bind(exchange, queue, RoutingKey);

                // Now you can publish a message to the exchange
                var message = new Message<string>("Hello, EasyNetQ with exchange!");
                advancedBus.Publish(exchange, RoutingKey, false, message);

            }
        }
    }

    
}