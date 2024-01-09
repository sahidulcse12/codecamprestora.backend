

using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Enums;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public record UpdateBranchCommand : IRequest< BranchDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
    public IList<BranchOpeningClosingTimeDTO>? BranchOpeningClosingTime { get; set; }
    public IList<BranchCuisineTypeDTO>? BranchCuisineType { get; set; }
    public BranchAddressDTO? BranchAddress { get; set; }

}
