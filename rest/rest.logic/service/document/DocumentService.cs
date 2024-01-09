using Rest.Dal;
using Rest.Logic.Service;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, IDocumentRepository, DocumentValidator>, IDocumentService
{
    private readonly IRabbitMqService _rabbitMqService;
    private readonly IMinioService _minioService;
    private readonly IElasticSearchIndexService _elasticSearchIndexService;

    public DocumentService(IDocumentRepository repository, IRabbitMqService rabbitMqService, IMinioService minioService, IElasticSearchIndexService elasticSearchIndexService) : base(repository, new DocumentValidator())
    {
        _rabbitMqService = rabbitMqService;
        _minioService = minioService;
        _elasticSearchIndexService = elasticSearchIndexService;
    }

    public override Document Add(Document entity)
    {
        var document = base.Add(entity);

        _rabbitMqService.SendDocumentMessage(document.Id);
        _minioService.AddDocument(document.Id, document.FileStream!, document.Title);
        _elasticSearchIndexService.IndexDocumentAsync("documents", document);

        return document;
    }
}
