using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
<<<<<<< Updated upstream:CodeCampRestora.Infrastructure/Data/DbContexts/ApplicationDbContext.cs
=======
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
    public DbSet<Comment> Comments => Set<Comment>();
>>>>>>> Stashed changes:src/CodeCampRestora.Infrastructure/Data/DbContexts/ApplicationDbContext.cs
}
