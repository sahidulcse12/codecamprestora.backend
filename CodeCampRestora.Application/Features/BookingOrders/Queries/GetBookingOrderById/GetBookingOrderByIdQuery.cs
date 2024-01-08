using CodeCampRestora.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById
{
    public class GetBookingOrderByIdQuery : IRequest<BookingOrderDTO>
    {
        public Guid Id { get; set; }
        public GetBookingOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
