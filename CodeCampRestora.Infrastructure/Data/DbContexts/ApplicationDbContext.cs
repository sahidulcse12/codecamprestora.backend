using CodeCampRestora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<MenuItem> menuItems => Set<MenuItem>();
    }
}
