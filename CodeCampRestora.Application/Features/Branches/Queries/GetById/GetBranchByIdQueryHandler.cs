using MediatR;
using CodeCampRestora.Application.DTOs;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDTO>
    {
        public Task<BranchDTO> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
