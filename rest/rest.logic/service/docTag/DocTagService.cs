using Rest.Dal;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocTagService : CrudService<DocTag, IDocTagRepository, DocTagValidator>, IDocTagService
{
    public DocTagService(IDocTagRepository repository) : base(repository, new DocTagValidator())
    {
        // noop
    }
}
