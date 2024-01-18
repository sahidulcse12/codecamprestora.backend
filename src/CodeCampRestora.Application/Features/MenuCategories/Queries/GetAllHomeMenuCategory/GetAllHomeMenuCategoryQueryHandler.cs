using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetAllHomeMenuCategory
{
    public class GetAllHomeMenuCategoryQueryHandler : IQueryHandler<GetAllHomeMenuCategoryQuery, IResult<List<MenuCategoryDto>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public GetAllHomeMenuCategoryQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public async Task<IResult<List<MenuCategoryDto>>> Handle(GetAllHomeMenuCategoryQuery request, CancellationToken cancellationToken)
        {
            var result =await _menuCategoryService.GetAllHomeMenuCategoryAsync();
            return result;
        }
    }
}
