using Rest.Dal;
using Rest.Logic.Service;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, IDocumentRepository, DocumentValidator>, IDocumentService
{
    private readonly IRabbitMqService _rabbitMqService;
    private readonly IMinioService _minioService;

    public DocumentService(IDocumentRepository repository, IRabbitMqService rabbitMqService, IMinioService minioService) : base(repository, new DocumentValidator())
    {
        _rabbitMqService = rabbitMqService;
        _minioService = minioService;
    }

    public override Document Add(Document entity)
    {
        var document = base.Add(entity);

        _rabbitMqService.SendDocumentMessage(document.Id);
        _minioService.AddDocument(document.Id, document.OriginalFileName);

        return document;
    }
}
