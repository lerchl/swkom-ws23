using Rest.Dal;
using Rest.Logic.Validation;
using Rest.Model;

namespace Rest.Logic.Service;

public class CorrespondentService : CrudService<Correspondent, ICorrespondentRepository, CorrespondentValidator>, ICorrespondentService
{
    public CorrespondentService(ICorrespondentRepository repository) : base(repository)
    {
        // noop
    }
}
