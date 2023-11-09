using Microsoft.EntityFrameworkCore;
using Rest.Model;

namespace Rest.Dal;

public class DbDocumentTypeRepository : DbCrudRepository<DocumentType, PostgreContext>, IDocumentTypeRepository
{
    protected override DbSet<DocumentType> GetDbSet(PostgreContext context)
    {
        return context.DocumentTypes;
    }
}
