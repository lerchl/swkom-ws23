using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, IDocumentRepository>, IDocumentService
{
    public DocumentService(IDocumentRepository repository) : base(repository)
    {
        // noop
    }
}
