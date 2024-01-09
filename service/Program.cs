using EasyNetQ;
using Microsoft.Extensions.Configuration;

namespace Service;

public class Program
{

    private static readonly string CONNECTION_STRING_NAME = "RabbitMQ";

    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

    private static readonly OcrClient ocrClient = new();
    private static readonly MinioService minioService = new();

    public static void Main(String[] args)
    {
        using (var bus = RabbitHutch.CreateBus(CONFIG.GetConnectionString(CONNECTION_STRING_NAME)))
        {
            bus.Advanced.Consume<long>(bus.Advanced.QueueDeclare("document_queue"), (message, info) => ProcessMessage(message.Body));

            for (;;) {
                // hihi
            }
        }
    }

    private static void ProcessMessage(long id)
    {
        // get document from MinIO
        minioService.streamDocument(id, stream =>
        {
            // send document to OCR
            var ocrResult = ocrClient.OcrPdf(stream);

            // write text into database
            using (var db = new PostgreContext())
            {
                var document = db.Documents.Find(id)!;
                document.Text = ocrResult;
                db.SaveChanges();
            }
        });
    }
}

