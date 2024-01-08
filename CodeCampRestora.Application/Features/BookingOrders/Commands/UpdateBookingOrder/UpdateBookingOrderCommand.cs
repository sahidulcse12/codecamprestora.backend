using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder
{
    public class UpdateBookingOrderCommand : IRequest<BookingOrderDTO>
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
