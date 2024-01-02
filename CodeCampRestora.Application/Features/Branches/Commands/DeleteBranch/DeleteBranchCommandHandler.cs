

using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Domain.Entities.Branches;
using MediatR;
using MediatR.Pipeline;

namespace CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, string>
{
    private readonly IRepository<Branch, Guid> _repository;

    public DeleteBranchCommandHandler(IRepository<Branch, Guid> repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _repository.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Branch Not Found");
        }
        await _repository.DeleteAsync(request.Id);
        
        return "Deleted Sucessufully";
    }
}
 