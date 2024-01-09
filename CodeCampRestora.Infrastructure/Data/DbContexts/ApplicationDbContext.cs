using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Domain.Entities.Reviews;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Reviews> Reviews => Set<Reviews>();
}
