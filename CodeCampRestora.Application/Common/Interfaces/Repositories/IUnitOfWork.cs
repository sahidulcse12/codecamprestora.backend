namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IMenuItemRepository MenuItem { get; }
    Task SaveChangesAsync();
}