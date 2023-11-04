using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class DocTagService : CrudService<DocTag, IDocTagRepository>, IDocTagService
{
    public DocTagService(IDocTagRepository repository) : base(repository)
    {
        // noop
    }
}
