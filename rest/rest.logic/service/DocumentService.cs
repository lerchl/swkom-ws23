using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentService : CrudService<Document, DbDocumentRepository>, IDocumentService
{
    public DocumentService(DbDocumentRepository repository) : base(repository)
    {
        // noop
    }
}
