using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.Extensions.Configuration;

namespace Rest.Logic.Service;

public class RabbitMqService : IRabbitMqService
{

	private static readonly string CONNECTION_STRING_NAME = "RabbitMQ";

	private static readonly string EXCHANGE_NAME = "document_exchange";
	private static readonly string QUEUE_NAME = "document_queue";
	private static readonly string ROUTING_KEY = "document_routing_key";

	private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false, true)
			.Build();

	private readonly Exchange _exchange;

	public RabbitMqService() {
		using (var bus = RabbitHutch.CreateBus(CONFIG.GetConnectionString(CONNECTION_STRING_NAME))) {
			var advancedBus = bus.Advanced;

			// Declare the exchange
			_exchange = advancedBus.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct);

			// Declare the queue
			var queue = advancedBus.QueueDeclare(QUEUE_NAME);

			// Bind the queue to the exchange
			advancedBus.Bind(_exchange, queue, ROUTING_KEY);
		}
	}

	public void SendDocumentMessage(long documentId) {
		using (var bus = RabbitHutch.CreateBus(CONFIG.GetConnectionString(CONNECTION_STRING_NAME))) {
			var advancedBus = bus.Advanced;

			advancedBus.Publish(_exchange, ROUTING_KEY, false, new Message<long>(documentId));
		}
	}
}
