using Microsoft.EntityFrameworkCore;
using Rest.Model;

namespace Rest.Dal;

public class DbDocTagRepository : DbCrudRepository<DocTag, PostgreContext>, IDocTagRepository
{
    protected override DbSet<DocTag> GetDbSet(PostgreContext context)
    {
        return context.DocTags;
    }
}
