using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class CorrespondentService : CrudService<Correspondent, ICorrespondentRepository>, ICorrespondentService
{
    public CorrespondentService(ICorrespondentRepository repository) : base(repository)
    {
        // noop
    }
}
