using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IReviewRepository Reviews { get; }
    public IRestaurantRepository Restaurants { get; }
    public IMenuItemRepository MenuItem { get; }
    public IMenuCategoryRepository MenuCategory { get; }

    private readonly IApplicationDbContext _appplicationDbContext;

    public UnitOfWork(
        IImageRepository images,
        IRestaurantRepository restaurants,
        IMenuItemRepository menuItem,
        IMenuCategoryRepository menuCategory,
        IReviewRepository review,
        IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        Restaurants = restaurants;
        MenuItem = menuItem;
        MenuCategory = menuCategory;
        Reviews = review;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }
}
