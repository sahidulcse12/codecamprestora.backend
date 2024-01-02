using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
