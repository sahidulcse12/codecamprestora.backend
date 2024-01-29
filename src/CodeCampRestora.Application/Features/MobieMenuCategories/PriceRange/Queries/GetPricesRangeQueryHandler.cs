using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.MobieMenuCategories.PriceRange.Queries;
public class GetPricesRangeQueryHandler : IQueryHandler<GetPricesRangeQuery, IResult<List<BranchListDTO>>>
{
    private readonly IUnitOfWork _uniOfWork;
    public GetPricesRangeQueryHandler(IUnitOfWork unitOfWork)
    {
        _uniOfWork = unitOfWork;
    }
    public async Task<IResult<List<BranchListDTO>>> Handle(GetPricesRangeQuery request, CancellationToken cancellationToken)
    {
        var branch = await _uniOfWork.Branches.IncludeProps(i => i.PriceRange).ToListAsync();

        var branchdto = branch.Adapt<BranchListDTO>();
        return Result<List<BranchListDTO>>.Success(new List<BranchListDTO> { branchdto });
    }
}

