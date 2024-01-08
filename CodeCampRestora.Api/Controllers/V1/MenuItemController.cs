using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1
{
    public class MenuItemController : ApiBaseController
    {
        [HttpPost]
        [SwaggerOperation(summary: "create a menu item")]
        public async Task<IResult> Post([FromBody] CreateMenuItemCommand command)
        {
            var result = await Sender.Send(command);
            return (IResult)result;
        }
    }
}