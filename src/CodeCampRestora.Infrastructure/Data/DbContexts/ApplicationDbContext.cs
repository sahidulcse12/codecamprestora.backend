using CodeCampRestora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Domain.Entities.Orders;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Order> Orders {  get; set; }
    public DbSet<OrderItem> OrderItems {  get; set; }
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
}
