using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById
{
    public record GetBookingOrderByIdQuery : IQuery<IResult<BookingOrderDTO>>
    {
        public Guid Id { get; set; }
        public GetBookingOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
