using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using Mapster;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public class CreateMenuItemCommandHandler : ICommandHandler<CreateMenuItemCommand, IResult>
    {
        private readonly IMenuItemService _menuItemService;
        public CreateMenuItemCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public Task<IResult> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var MenuItems = request.Adapt<MenuItem>();
            var result = _menuItemService.CreateItemAsync(MenuItems);
            return result;
        }
    }
}