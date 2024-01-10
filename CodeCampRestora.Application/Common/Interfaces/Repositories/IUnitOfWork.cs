namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IReviewRepository Reviews { get; }
    IRestaurantRepository Restaurants { get; }
    Task SaveChangesAsync();
}