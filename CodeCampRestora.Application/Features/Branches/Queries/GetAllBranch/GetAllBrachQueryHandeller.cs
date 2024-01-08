

using CodeCampRestora.Application.DTOs;
using MediatR;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public class GetAllBrachQueryHandeller : IRequestHandler<GetAllBranchesQuery, List<BranchDTO>>
{
    private readonly IBranchRepository _repository; 
    public GetAllBrachQueryHandeller(IBranchRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<BranchDTO>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        var resturant = await _repository.GetByIdAsync(request.ResturantId);
        var branches = new List<BranchDTO>();
        if (resturant != null)
        {
            // branches = resturant.Branches.Select(x => new BranchDTO
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    IsAvailable = x.IsAvailable,
            //}).ToList(); 
        }
 
        return branches;
    }

}
