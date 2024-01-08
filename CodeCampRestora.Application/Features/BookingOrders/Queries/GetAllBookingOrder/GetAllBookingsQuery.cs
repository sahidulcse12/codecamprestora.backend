using CodeCampRestora.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder
{
    public class GetAllBookingsQuery : IRequest<List<BookingOrderDTO>>
    {
    }
}
