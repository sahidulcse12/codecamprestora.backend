using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class  CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDTO>
{
    public CreateBranchCommandHandler()
    {
    }

    public async Task<BranchDTO> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch
        {
            Name = request.Name,
            IsAvailable = request.IsAvailable,
            PriceRange = request.PriceRange,
        };
       // _repsitory.Add(branch);

        return new BranchDTO
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
        };
    }
}
