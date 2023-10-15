using Microsoft.EntityFrameworkCore;
using Rest.Dal;
using Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Dal {
    public class DbDocumentRepository : DbCrudRepository<Document, PostgreContext>, IDocumentRepository {
        protected override DbSet<Document> GetDbSet(PostgreContext context) {
            return context.Documents!;
        }
    }
}
