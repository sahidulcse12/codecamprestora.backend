
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Domain.Entities.Branches;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, BranchDTO>
{
    public readonly IRepository<Branch, Guid> _repository;
    public UpdateBranchCommandHandler(IRepository<Branch, Guid> repository)
    {
        _repository = repository;
    }
    public async Task<BranchDTO> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _repository.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Not Found the Brach");
        }
        branch.Name = request.Name;
        branch.IsAvailable = request.IsAvailable;
        branch.PriceRange = request.PriceRange;

        return new BranchDTO
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
        };


    }
}
