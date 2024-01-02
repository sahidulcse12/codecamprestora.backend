

using CodeCampRestora.Application.DTOs;
using BranchEO = CodeCampRestora.Domain.Entities.Branchs.Branch;
using MediatR;

namespace CodeCampRestora.Application.Features.Branch.Queries.GetAllBranch;

public class GetAllBrachQueryHandeller : IRequestHandler<GetAllBranchesQuery, BranchDto>
{
    public async Task<BranchDto> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        var branch = new BranchEO
        {
            Name = request.Name,
            IsAvailable = request.IsAvailable,
            PriceRange = request.PriceRange,
        };
        return new BranchDto
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
        };
    }
}
