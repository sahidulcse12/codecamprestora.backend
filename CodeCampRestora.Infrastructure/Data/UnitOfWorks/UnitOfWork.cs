using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;
 
[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _appplicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
