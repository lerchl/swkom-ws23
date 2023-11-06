using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentTypeService : CrudService<DocumentType, IDocumentTypeRepository>, IDocumentTypeService
{
    public DocumentTypeService(IDocumentTypeRepository repository) : base(repository)
    {
        // noop
    }
}
