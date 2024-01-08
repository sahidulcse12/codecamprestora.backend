using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;
 
[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IBranchRepository Branches { get; } 
    private readonly ApplicationDbContext _appplicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext, IBranchRepository branches)
    {
        _appplicationDbContext = applicationDbContext;
        Branches = branches;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }

    //public void Dispose()
    //{
    //    throw new NotImplementedException();
    //}
}
