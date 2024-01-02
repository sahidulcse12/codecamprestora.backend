using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branchs;
using MediatR;


namespace CodeCampRestora.Application.Features.Branch.Queries.GetAllBranch;

public record GetAllBranchesQuery : IRequest<BranchDto>
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
}
