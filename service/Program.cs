using EasyNetQ;
using Microsoft.Extensions.Configuration;

namespace Service;

public class Program {

	private static readonly string CONNECTION_STRING_NAME = "RabbitMQ";

	private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false, true)
			.Build();

    private static readonly OcrClient ocrClient = new();

	public static void Main(String[] args) {
		using (var bus = RabbitHutch.CreateBus(CONFIG.GetConnectionString(CONNECTION_STRING_NAME))) {
			bus.PubSub.Subscribe<Message<long>>("", idMessage => Console.WriteLine($"Received message: {idMessage.Body}"));
		}

		for (;;) {
			// hihi
		}
	}

	private static void Process(long id) {
        // get document from MinIO
        Stream document = null;

        // send document to OCR
        var ocrResult = ocrClient.OcrPdf(document);

        // write text into database
        using (var db = new PostgreContext()) {
            var document = db.Documents.Find(id);
            document.Text = ocrResult.Text;
            db.SaveChanges();
        }
    }
}
