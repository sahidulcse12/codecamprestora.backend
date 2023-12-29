using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appplicationDbContext;
        public UnitOfWork(AppDbContext applicationDbContext) 
        { 
            _appplicationDbContext = applicationDbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _appplicationDbContext.SaveChangesAsync();
        }
    }
}
