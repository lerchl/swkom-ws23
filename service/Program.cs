using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.Extensions.Configuration;

namespace service;

public class Program {

	private static readonly string CONNECTION_STRING_NAME = "RabbitMQ";

	private static readonly string EXCHANGE_NAME = "document_exchange";
	private static readonly string QUEUE_NAME = "document_queue";
	private static readonly string ROUTING_KEY = "document_routing_key";

	private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false, true)
			.Build();

	private readonly Exchange _exchange;

	public static void Main(String[] args) {
		var client = new OcrClient();

		using (var bus = RabbitHutch.CreateBus(CONFIG.GetConnectionString(CONNECTION_STRING_NAME))) {
			bus.PubSub.Subscribe<Message<long>>("", idMessage => Console.WriteLine($"Received message: {idMessage.Body}"));
		}

		for (;;) {
			// hihi
		}
	}
}
