namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IOrderRepository Orders { get; }
    IRestaurantRepository Restaurants { get; }
    Task SaveChangesAsync();
}