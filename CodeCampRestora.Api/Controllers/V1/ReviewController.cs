using CodeCampRestora.Application.DTOs;


using CodeCampRestora.Application.Features.Review.Queries.GetAllReview;
using CodeCampRestora.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using CodeCampRestora.Application.Features.Review.Commands.CreateReview;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ApiBaseController
    {
        private readonly ILogger<ReviewController> _logger;
       

        public ReviewController(ILogger<ReviewController> logger)
        {
            _logger = logger;
           
        }

        [HttpGet]
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

      
        /* [HttpPatch]
         public async Task<IResult> Update([FromBody] UpdateBookingOrderCommand bookingOrder)
         {
             var result = await Sender.Send(bookingOrder);
             return result;
         }
 */

    }
}
