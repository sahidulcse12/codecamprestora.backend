using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Models;
using Mapster;

namespace CodeCampRestora.Application.Features.MenuCategory.Commands;

public class CreateMenuCategoryCommandHandler : ICommandHandler<CreateMenuCategoryCommand, IResult>
{
    private readonly IMenuCategoryService _menuCategoryService;
    public CreateMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }
    public async Task<IResult> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
    {
        var MenuCategories = request.Adapt<CodeCampRestora.Domain.Entities.MenuCategory>();
        IResult<Guid> result = (IResult<Guid>)_menuCategoryService.CreateCategoryAsync(MenuCategories);
        return result;
    }
}
