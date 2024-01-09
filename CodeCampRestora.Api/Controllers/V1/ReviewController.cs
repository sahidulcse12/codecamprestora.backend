using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ApiBaseController
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IMediator _mediator;

        public ReviewController(ILogger<ReviewController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult<List<ReviewDTO>>> GetAll()
        {
            var request = new GetAllReviewQuery();
            var response = await Sender.Send(request);
            return response;
        }

       

        [HttpPost]
        public async Task<Application.Models.IResult> Post([FromBody] CreateReviewCommand createReview)
        {
            var result = await Sender.Send(createReview);
            return result;
        }

       /* [HttpPatch]
        public async Task<IResult> Update([FromBody] UpdateBookingOrderCommand bookingOrder)
        {
            var result = await Sender.Send(bookingOrder);
            return result;
        }
*/

    }
}
