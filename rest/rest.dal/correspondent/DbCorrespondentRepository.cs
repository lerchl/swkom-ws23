using Microsoft.EntityFrameworkCore;
using Rest.Model;

namespace Rest.Dal;

public class DbCorrespondentRepository : DbCrudRepository<Correspondent, PostgreContext>, ICorrespondentRepository
{
    protected override DbSet<Correspondent> GetDbSet(PostgreContext context)
    {
        return context.Correspondents;
    }
}
