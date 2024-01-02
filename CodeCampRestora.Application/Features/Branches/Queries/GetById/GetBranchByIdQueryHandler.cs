using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Exceptions;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDTO>
    {
        private readonly IRepository<Branch,  Guid> _repository;
        public GetBranchByIdQueryHandler(IRepository<Branch, Guid> repository)
        {
            _repository = repository;
        }
        public async Task<BranchDTO> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id);
            if(branch == null)
            {
                throw new ResourceNotFoundException("Branch Not found");
            }

            return new BranchDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                IsAvailable = branch.IsAvailable,
                PriceRange = branch.PriceRange,
            };
             
        }
    }
}
