using CodeCampRestora.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Branch>()
            .HasMany(c => c.OpeningClosingTimes)
            .WithOne(e => e.Branch);
        modelBuilder.Entity<Branch>()
            .HasMany(i => i.CuisineTypes)
            .WithOne(e => e.Branch);
    }
}
