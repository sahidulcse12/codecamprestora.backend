using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder
{
    public record CreateBookingOrderCommand : ICommand<IResult<BookingOrderDTO>>
    {
        public string CustomerName { get; set; } = default!;
        public string CustomerMobileNumber { get; set; } = default!;
        public DateTime BookingTime { get; set; }
        public BookingType BookingType { get; set; }
        public int NoOfSeats { get; set; } = default!;
        public OrderStatus OrderStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderTrackingNumber { get; set; }
        public string SpecialNote { get; set; } = string.Empty;
        public string TimeNeededForServing { get; set; } = string.Empty;
        public double SubTotal { get; set; }
        public double VAT { get; set; }
        public double DeliveryCharge { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
