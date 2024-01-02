using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Enums;
using MediatR;


namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public record GetAllBranchesQuery : IRequest<List<BranchDTO>>
{
    public Guid ResturantId { get; set; }
}

