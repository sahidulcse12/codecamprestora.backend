using System.ComponentModel.Design;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Infrastructure.Data.Repositories;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _appplicationDbContext;
    public UnitOfWork(
        ApplicationDbContext applicationDbContext)
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
