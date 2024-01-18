using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetAllHomeMenuCategory
{
    public class GetAllHomeMenuCategoryQuery : IQuery<IResult<List<MenuCategoryDto>>>
    {
    }
}
