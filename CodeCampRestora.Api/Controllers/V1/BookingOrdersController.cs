using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder;
using CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById;
using IResult = CodeCampRestora.Application.Models.IResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingOrdersController : ApiBaseController
    {
        private readonly ILogger<BookingOrdersController> _logger;
        private readonly IMediator _mediator;

        public BookingOrdersController(ILogger<BookingOrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult<List<BookingOrderDTO>>> GetAll()
        {
            var request = new GetAllBookingsQuery();
            var response = await Sender.Send(request);
            return response;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IResult<BookingOrderDTO>> Get(Guid id)
        {
            var response = await Sender.Send(new GetBookingOrderByIdQuery(id));
            return response;
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateBookingOrderCommand bookingOrder)
        {
            var result = await Sender.Send(bookingOrder);
            return result;
        }

        [HttpPut]
        public async Task<IResult> Update([FromBody] UpdateBookingOrderCommand bookingOrder)
        {
            var result = await Sender.Send(bookingOrder);
            return result;
        }


    }
}
