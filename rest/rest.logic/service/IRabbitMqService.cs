namespace Rest.Logic.Service;

public interface IRabbitMqService
{
	void SendDocumentMessage(long documentId);
}
