using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public record CreateMenuItemCommand(
        string Name,
        string Description,
        string Ingredients, 
        double Price,
        int DisplayOrder, 
        int CategoryId,
        int RestaurantId 
    ) : ICommand<IResult>;
}