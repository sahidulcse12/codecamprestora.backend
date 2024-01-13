using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;
using CodeCampRestora.Application.Features.Reviews.Commands.HiddenReview;
using CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;
using CodeCampRestora.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ApiBaseController
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Getting All Reviews",
            Description = @"Sample Request:
            Post: api/v1/Review
            {
            ""BranchId"": ""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""OrderId"":""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""Rating"":""4"",
            ""Description"":""Someting""
            }"
        )]
        public async Task<IResult<List<ReviewDTO>>> GetAll()
        {
            var request = new GetAllReviewQuery();
            var response = await Sender.Send(request);
            return response;
        }
        [HttpPost]
        public async Task<Application.Models.IResult> Post([FromBody]CreateReviewCommand reviewCommand)
        {
            var result = await Sender.Send(reviewCommand);
            return result;
        }
        [HttpPatch("{reviewId}/hide-show")]
        [SwaggerOperation(
            Summary = "Hide or Show a Review",
            Description = @"Sample Request:
            Patch: api/v1/Review/{reviewId}/hide-show
            {
             ""hideReview"": true
            }"
        )]
        public async Task<Application.Models.IResult> HideShowReview(Guid reviewId, [FromBody] HiddenReviewCommand hideShowReviewCommand)
        {
            hideShowReviewCommand.ReviewId = reviewId;
            var result = await Sender.Send(hideShowReviewCommand);
            return result;
        }
    }
}
