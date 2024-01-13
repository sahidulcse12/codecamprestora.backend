using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;
[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IReviewRepository Reviews { get; }
    public IRestaurantRepository Restaurants { get; }

    private readonly IApplicationDbContext _appplicationDbContext;
    public UnitOfWork(IImageRepository images,IReviewRepository review,IRestaurantRepository restaurants,IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        Restaurants = restaurants;
        Reviews = review;
    }
   

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }
}
