using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rest.Model;

namespace Rest.Dal;

/// <summary>
///     <see cref="DbContext"/> for the Postgre database supplied in appsettings.json.
/// </summary>
public class PostgreContext : DbContext
{

    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    public DbSet<Correspondent> Correspondents { get; set; }
    public DbSet<DocTag> DocTags { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }


    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(CONFIG.GetConnectionString("PostgreContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>()
            .HasMany(e => e.Tags)
            .WithMany();
    }
}
