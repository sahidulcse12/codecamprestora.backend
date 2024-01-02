

using CodeCampRestora.Application.DTOs;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById;

public record GetBranchByIdQuery(Guid Id) : IRequest<BranchDTO>;
