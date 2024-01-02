

using CodeCampRestora.Application.DTOs;
using MediatR;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public class GetAllBrachQueryHandeller : IRequestHandler<GetAllBranchesQuery, List<BranchDTO>>
{
    public GetAllBrachQueryHandeller()
    {
        
    }
    public async Task<List<BranchDTO>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        var brachesDto = new List<BranchDTO>();
        //foreach (var branch in branches)
        //{
        //    brachesDto.Add(new BranchDTO()
        //    {
        //        Name = branch.Name,
        //        IsAvailable = branch.IsAvailable,
        //        PriceRange = branch.PriceRange,
        //    });
            
        //}

        return brachesDto;
        
    }

}
