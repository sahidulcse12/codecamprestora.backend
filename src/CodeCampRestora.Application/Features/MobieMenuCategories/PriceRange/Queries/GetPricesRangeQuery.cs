using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MobieMenuCategories.PriceRange.Queries;

public class GetPricesRangeQuery : IQuery<IResult<List<BranchListDTO>>>
{
}

