using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.ReviewComments;
using IResult = CodeCampRestora.Application.Models.IResult;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class ReviewCommentController : ApiBaseController
{
    [HttpPost]
    public async Task<IResult> Create([FromBody] CreateReviewCommentCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
