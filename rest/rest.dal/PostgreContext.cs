using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Rest.Dal {

    /// <summary>
    ///     <see cref="DbContext"/> for the Postgre database supplied in appsettings.json.
    /// </summary>
    public class PostgreContext : DbContext {

        private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();


        // /////////////////////////////////////////////////////////////////////////
        // Methods
        // /////////////////////////////////////////////////////////////////////////

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(CONFIG.GetConnectionString("PostgreContext"));
        }
    }
}
