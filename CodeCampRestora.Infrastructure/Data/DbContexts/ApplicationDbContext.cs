using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    modelBuilder.Entity<Branch>()
    //        .HasMany(c => c.OpeningClosingTimes)
    //        .WithOne(e => e.Branch)
    //        .HasForeignKey(e => e.BranchId);
    //    modelBuilder.Entity<Branch>()
    //        .HasMany(i => i.CuisineTypes)
    //        .WithOne(e => e.Branch)
    //        .HasForeignKey(e => e.BranchId);
    //    modelBuilder.Entity<Branch>()
    //        .HasOne(i => i.Address)
    //        .WithOne(i => i.Branch)
    //        .HasForeignKey<Address>(e => e.BranchId);
    //    modelBuilder.Entity<Restaurant>()
    //        .HasMany(i => i.Categories)
    //        .WithOne(i => i.Restaurant)
    //        .HasForeignKey(x => x.RestaurantId);
       
    //}

    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
     public DbSet<Branch> Branches => Set<Branch>();
}
