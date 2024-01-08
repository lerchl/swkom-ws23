using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Service;

/// <summary>
///     <see cref="DbContext"/> for the Postgre database supplied in appsettings.json.
/// </summary>
public class PostgreContext : DbContext
{

    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    public DbSet<Document> Documents { get; set; }


    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(CONFIG.GetConnectionString("PostgreContext"));
    }
}
