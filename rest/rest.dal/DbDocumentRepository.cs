using Microsoft.EntityFrameworkCore;
using Rest.Model;

namespace Rest.Dal {
    public class DbDocumentRepository : DbCrudRepository<Document, PostgreContext>, IDocumentRepository {
        protected override DbSet<Document> GetDbSet(PostgreContext context) {
            return context.Documents!;
        }
    }
}
