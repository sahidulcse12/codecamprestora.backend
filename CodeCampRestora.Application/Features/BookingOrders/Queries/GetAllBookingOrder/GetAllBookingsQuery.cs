using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder
{
    public record GetAllBookingsQuery : IQuery<IResult<List<BookingOrderDTO>>>
    {
    }
}
