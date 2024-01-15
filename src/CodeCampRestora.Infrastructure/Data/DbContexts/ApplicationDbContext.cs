using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
        .HasOne(u => u.Staff)
        .WithOne(t => t.ApplicationUser)
        .HasForeignKey<Staff>(b => b.ApplicationUserId)
        .IsRequired(false);

        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<ApplicationRole>().HasData
        (
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "MANAGER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Waiter", ConcurrencyStamp = "2", NormalizedName = "WAITER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "User", ConcurrencyStamp = "4", NormalizedName = "USER" }
        );
    }

    public DbSet<T> DbSet<T>() where T: class => Set<T>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Staff> Staffs => Set<Staff>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    // public DbSet<Branch> Branches => Set<Branch>();
    // public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    // public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
}
