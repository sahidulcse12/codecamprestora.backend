using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Enums;
using MediatR;


namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public record GetAllBranchesQuery : IRequest<List<BranchDTO>>
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
}

