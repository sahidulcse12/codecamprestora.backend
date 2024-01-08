using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Domain.Entities.BookingOrders;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Image> Images => Set<Image>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<BookingOrder> BookingsOrders {  get; set; }
    public DbSet<OrderItem> OrderItems {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingOrder>()
            .HasMany(b => b.OrderItems)
            .WithOne(o => o.BookingOrder)
            .HasForeignKey(o => o.BookingOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.BookingOrder)
            .WithMany(b => b.OrderItems)
            .HasForeignKey(o => o.BookingOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
