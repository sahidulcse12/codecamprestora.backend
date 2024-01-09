using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using FluentValidation;


namespace CodeCampRestora.Application.Features.MenuCategories.Commands.CreateMenuCategory
{
    public class CreateMenuCategoryCommandValidator : ApplicationValidator<CreateMenuCategoryCommand>
    {
        public CreateMenuCategoryCommandValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("Name can't be empty");
            RuleFor(item => item.RestaurantId).NotEmpty().WithMessage("RestaurantId can't be emptly");
        }
    }
}