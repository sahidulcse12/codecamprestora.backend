using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuCategoryRepository : Repository<MenuCategory, Guid>, IMenuCategoryRepository
{
    private readonly DbSet<MenuCategory> _menuCategory;
    public MenuCategoryRepository(ApplicationDbContext applicationDbContext) 
    : base(applicationDbContext)
    { 
        _menuCategory = applicationDbContext.Set<MenuCategory>();
    }

    public async Task<List<MenuCategory>> GetAllByIdAsync(Guid Id)
    {
        var Entities = _menuCategory.Where(e => e.RestaurantId == Id).ToList();
        return Entities;
    }
}