namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IBranchRepository Branches { get; }

    Task SaveChangesAsync();
}

