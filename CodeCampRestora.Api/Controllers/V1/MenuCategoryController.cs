using CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1;

public class MenuCategoryController : ApiBaseController
{
    [HttpPost]
    [SwaggerOperation(summary: "Create a menu category")]
    public async Task<IResult> Post([FromBody] CreateMenuCategoryCommand command)
    {
        var result = Sender.Send(command);
        return (IResult)result;
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerOperation(summary: "Delete a menu category")]
    public async Task<IResult> Delete(Guid Id)
    {
        var result = Sender.Send(new DeleteMenuCategoryCommand(Id));
        return (IResult)result;
    }
}