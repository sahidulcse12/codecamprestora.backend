using MediatR;
using CodeCampRestora.Domain.Enums;
using CodeCampRestora.Application.DTOs;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public record CreateBranchCommand : IRequest<BranchDTO>
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
}
