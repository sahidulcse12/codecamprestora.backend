using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder
{
    public record UpdateBookingOrderCommand : ICommand<IResult>
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
