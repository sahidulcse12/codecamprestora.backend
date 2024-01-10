using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;
using MediatR;


namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public record GetAllBranchesQuery : IQuery<IResult<BranchDTO>>
{
    public Guid ResturantId { get; set; }
}

