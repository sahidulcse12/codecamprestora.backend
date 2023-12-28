using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
