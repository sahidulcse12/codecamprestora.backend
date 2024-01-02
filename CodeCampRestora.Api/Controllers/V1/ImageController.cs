using CodeCampRestora.Application.Features.Images.Commands.CreateImage;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1;

public class ImageController : ApiBaseController
{
    [SwaggerOperation(
        Summary = "Upload image",
        Description = "Upload an image file"
    )]
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody, SwaggerRequestBody(Required = true, Description = "image payload")]
        CreateImageCommand command)
    {
        await Sender.Send(command);
        return Ok();
    }
}