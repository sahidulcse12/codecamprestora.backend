

using CodeCampRestora.Application.DTOs;
using MediatR;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using Microsoft.AspNetCore.Http;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public class GetAllBrachQueryHandeller : IQueryHandler<GetAllBranchesQuery, IResult<List<BranchListDTO>>>
{
    private readonly IUnitOfWork _uniOfWork;
    public GetAllBrachQueryHandeller(IUnitOfWork uniOfWork)
    {
        _uniOfWork = uniOfWork;
    }

    public async Task<IResult<List<BranchListDTO>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {

        var restaurant = await _uniOfWork
            .Restaurants
            .IncludeProps(resturant => resturant.Branches)
            .SingleOrDefaultAsync(restaurant => restaurant.Id == request.Id);

        if (restaurant is null)
        {
            return Result<List<BranchListDTO>>.Failure(
                StatusCodes.Status404NotFound,
                BranchErrors.NotFound);
        }

        var branchListDtos = restaurant.Branches.Select(branch => 
            branch.Adapt<BranchListDTO>()).ToList();

        return Result<List<BranchListDTO>>.Success(branchListDtos);
    }
}
