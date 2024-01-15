using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.ReviewComment;
using IResult = CodeCampRestora.Application.Models.IResult;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class ReviewCommentController : ApiBaseController
{
    [HttpPost]
    public async Task<IResult> Create([FromBody] ReviewCommentCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
