using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById;
using IResult = CodeCampRestora.Application.Models.IResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingOrdersController : ApiBaseController
    {
        private readonly ILogger<BookingOrdersController> _logger;

        public BookingOrdersController(ILogger<BookingOrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Get all booking orders",
        Description = @"Sample Request:
        Get: api/v1/BookingOrders"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Booking orders not found", typeof(IResult))]
        public async Task<IResult<List<BookingOrderDTO>>> GetAll()
        {
            var request = new GetAllBookingsQuery();
            var response = await Sender.Send(request);
            return response;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerOperation(
        Summary = "Get an booking order",
        Description = @"Sample Request:
        Get: api/v1/BookingOrders/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Booking order not found", typeof(IResult))]
        public async Task<IResult<BookingOrderDTO>> Get([FromRoute, SwaggerParameter(Description = "Get image by id", Required = true)] Guid id)
        {
            var response = await Sender.Send(new GetBookingOrderByIdQuery(id));
            return response;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Create a booking order",
        Description = @"Sample Request:
        Post: api/v1/BookingOrders
        {
            ""id"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB"",
            ""orderStatus"": 0,
        }"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IResult> Post([FromBody] CreateBookingOrderCommand bookingOrder)
        {
            var result = await Sender.Send(bookingOrder);
            return result;
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Create a booking order",
        Description = @"Sample Request:
        Put: api/v1/BookingOrder/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c
        {
            ""id"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB"",
            ""orderStatus"": 0,
        }"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IResult> Update([FromBody] UpdateBookingOrderCommand bookingOrder)
        {
            var result = await Sender.Send(bookingOrder);
            return result;
        }
    }
}
