using Rest.Dal;
using Rest.Logic.Service;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, IDocumentRepository, DocumentValidator>, IDocumentService
{
    public DocumentService(IDocumentRepository repository) : base(repository, new DocumentValidator())
    {
        // noop
    }
}
