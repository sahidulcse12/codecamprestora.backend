using System.ComponentModel.Design;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IRestaurantRepository Restaurants { get; }
    public IMenuItemRepository MenuItem { get; }
    public IReviewCommentRepository Comments { get; }
    public IMenuCategoryRepository MenuCategory { get; }

    private readonly IApplicationDbContext _appplicationDbContext;

    public UnitOfWork(
        IImageRepository images,
        IMenuItemRepository menuItem,
        IRestaurantRepository restaurants,
        IMenuCategoryRepository menuCategory,
        IReviewCommentRepository reviewComment,
        IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        MenuItem = menuItem;
        Comments = reviewComment;
        Restaurants = restaurants;
        MenuCategory = menuCategory;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }
}
