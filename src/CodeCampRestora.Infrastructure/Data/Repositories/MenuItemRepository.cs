using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Application.Common.Helpers.Pagination;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuItemRepository : Repository<MenuItem,Guid>, IMenuItemRepository
{
    private readonly DbSet<MenuItem> _menuItem;
    public MenuItemRepository(IApplicationDbContext applicationDbContext,
    ApplicationDbContext context)
        : base((DbContext) applicationDbContext)
    {
        _menuItem = context.Set<MenuItem>();
    }

    public async Task<List<MenuItem>> GetAllByIdAsync(Guid Id)
    {
        var Entities = _menuItem.Where(e => e.BranchId == Id).ToList();
        return Entities;
    }

    public async Task<PagedList<MenuItem>> GetPaginatedByIdAsync(
        Guid Id, int pageNumber, int pageSize
    )
    {
        var Entities = _menuItem.Where(e => e.BranchId == Id);
        var PagedList = await PagedList<MenuItem>.ToPagedListAsync(Entities, pageNumber, pageSize);
        return PagedList;
    }
}