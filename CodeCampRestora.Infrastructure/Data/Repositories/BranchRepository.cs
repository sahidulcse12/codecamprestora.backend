using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class BranchRepository : GenericRepository<Branch, Guid>, IBranchRepository
{
    public BranchRepository(ApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
        
    }
    
}
