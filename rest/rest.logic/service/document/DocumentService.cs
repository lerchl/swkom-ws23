using Rest.Dal;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, IDocumentRepository, DocumentValidator>, IDocumentService
{
    private readonly IRabbitMqService _rabbitMqService;

    public DocumentService(IDocumentRepository repository, IRabbitMqService rabbitMqService) : base(repository, new DocumentValidator())
    {
        _rabbitMqService = rabbitMqService;
    }

    public override Document Add(Document entity)
    {
        var document = base.Add(entity);

        _rabbitMqService.SendDocumentMessage(document.Id);

        return document;
    }
}
