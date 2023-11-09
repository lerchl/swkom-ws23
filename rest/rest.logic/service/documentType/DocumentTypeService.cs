using Rest.Dal;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocumentTypeService : CrudService<DocumentType, IDocumentTypeRepository, DocumentTypeValidator>, IDocumentTypeService
{
    public DocumentTypeService(IDocumentTypeRepository repository) : base(repository)
    {
        // noop
    }
}
